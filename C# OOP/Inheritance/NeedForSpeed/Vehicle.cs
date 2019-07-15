using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower,double fuel)
        {
            this.horsePower = horsePower;
            this.fuel = fuel;
        }

        private double fuel;
        private int horsePower;
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        public const double DefaultFuelConsumption = DEFAULT_FUEL_CONSUMPTION;



        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        

        public double Fuel
        {
            get { return this.fuel; }
            set { fuel = value; }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public virtual void Drive(double kilometers)
        {
            fuel -= kilometers * FuelConsumption;
        }
    }
}
