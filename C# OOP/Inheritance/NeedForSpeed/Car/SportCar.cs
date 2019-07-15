using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Car
{
    public class SportCar:Car
    {
        public const double defaultForClass = 10;
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => defaultForClass;
    }
}
