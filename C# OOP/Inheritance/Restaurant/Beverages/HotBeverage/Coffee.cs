using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages.HotBeverage
{
    public class Coffee:HotBeverage
    {
        private double caffeine;
        public const double  CoffeeMilliliters = 50;
        public const decimal CoffeePrice = 3.50M;

        public double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }


        public Coffee(string name,double caffeine) : base(name,CoffeePrice,CoffeeMilliliters)
        {
            this.caffeine = caffeine;
        }
    }
}
