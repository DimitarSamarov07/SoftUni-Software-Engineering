using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double fuelQuantity,double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + FuelConsumptionIncrease;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public virtual double FuelConsumptionIncrease { get; set; } = 0;
        public virtual double OutOfTank { get; set; } = 0;
     

        public virtual string Drive( double km)
        {
            string type = this.GetType().ToString().Replace("Vehicles.", "");
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
            if (OutOfTank!=0)
            {
                FuelQuantity += quantity*OutOfTank;
            }
            else
            {
                FuelQuantity += quantity;
            }
        }

        public override string ToString()
        {
            string type = this.GetType().ToString().Replace("Vehicles.", "");

            return $"{type}: {FuelQuantity:f2}";
        }
    }
}
