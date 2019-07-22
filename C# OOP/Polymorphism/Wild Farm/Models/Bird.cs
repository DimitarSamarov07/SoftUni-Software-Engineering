using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core
{
    public abstract class Bird:Animal
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" {WingSize}, {Weight}, {FoodEaten}]".TrimEnd();
        }

        
    }
}
