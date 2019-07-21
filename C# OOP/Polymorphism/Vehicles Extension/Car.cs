using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Vehicles_Extension
{
    public class Car:Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm,tankCapacity)
        {

        }

        public override double FuelConsumptionIncrease { get; set; } = 0.9;

    }
}
