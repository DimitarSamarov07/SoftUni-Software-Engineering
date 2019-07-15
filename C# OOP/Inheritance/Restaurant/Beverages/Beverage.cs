using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class Beverage:Product
    {
        private double milliliters;

        public double Milliliters
        {
            get { return this.milliliters; }
            set { milliliters = value; }
        }

        public Beverage(string name, decimal price,double milliliters) 
            : base(name, price)
        {
            this.milliliters = milliliters;
        }
    }
}
