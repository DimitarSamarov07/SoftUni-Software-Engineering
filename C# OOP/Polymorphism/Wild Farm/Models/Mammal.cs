﻿namespace Wild_Farm.Core
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight,string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{Weight} {LivingRegion} {FoodEaten}]".TrimEnd();
        }

        
    }
}
