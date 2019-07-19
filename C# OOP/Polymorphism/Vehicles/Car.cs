using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Vehicles
{
    public class Car:Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }

        public override double FuelConsumptionIncrease { get; set; } = 0.9;

    }
}
