using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles_Extension
{
    class Bus:Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            
        }

        public override double FuelConsumptionIncrease { get; set; } = 1.4;

    }
}
