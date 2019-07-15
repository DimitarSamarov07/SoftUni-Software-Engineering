using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Motorcycle
{
    public class RaceMotorcycle:Motorcycle
    {
        public const double defaultForClass = 8;
        public RaceMotorcycle(int horsePower,double fuel)
            :base(horsePower,fuel)
        {
            
        }

        public override double FuelConsumption => defaultForClass;
    }
}
