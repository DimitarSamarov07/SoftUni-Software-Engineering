using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Vehicles_Extension
{
    public class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity,double fuelConsumptionPerKm,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + FuelConsumptionIncrease;
        }

        public double FuelQuantity
        {
            get => fuelQuantity; 
            set
            {
                if (fuelQuantity<=TankCapacity)
                {
                    fuelQuantity = value;
                }

                else
                {
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                }
            }
        }

        public double FuelConsumptionPerKm { get; set; }
        public virtual double FuelConsumptionIncrease { get; set; } = 0;
        public virtual double OutOfTank { get; set; } = 0;
        public virtual double TankCapacity { get; set; }

        public virtual string Drive(double km)
        {
            string type = this.GetType().ToString().Replace("Vehicles_Extension.", "");
            if (this.FuelQuantity - FuelConsumptionPerKm * km >= 0)
            {
                FuelQuantity -= FuelConsumptionPerKm * km;
                return $"{type} travelled {km} km";
            }

            else
            {
                return $"{type} needs refueling";
            }
        }

        public virtual void Refuel(double quantity)
        {
            StringBuilder sb = new StringBuilder();
            if (quantity>0)
            {
                if (quantity+FuelQuantity>TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
                else if (OutOfTank!=0)
                {
                    FuelQuantity += quantity*OutOfTank;
                }
                else
                {
                    FuelQuantity += quantity;
                }
            }

            else
            {
               Console.WriteLine("Fuel must be a positive number");
            }

            
        }

        public virtual string DriveEmpty(double km)
        {
            FuelConsumptionPerKm -= FuelConsumptionIncrease;
            StringBuilder sb = new StringBuilder(Drive(km));
            FuelConsumptionIncrease += FuelConsumptionIncrease;
            return sb.ToString().TrimEnd();
        }

        public override string ToString()
        {
            string type = this.GetType().ToString().Replace("Vehicles_Extension.", "");

            return $"{type}: {FuelQuantity:f2}";
        }
    }
}
