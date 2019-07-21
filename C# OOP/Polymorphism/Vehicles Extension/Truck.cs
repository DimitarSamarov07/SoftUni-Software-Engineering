using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles_Extension
{
    public class Truck:Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm,tankCapacity)
        {

        }
        
        public override double FuelConsumptionIncrease { get; set; } = 1.6;
        public override double OutOfTank { get; set; } = 0.95;
    }
}
