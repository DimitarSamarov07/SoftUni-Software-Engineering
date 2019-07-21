using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wild_Farm.Core.Animals.Birds;
using Wild_Farm.Core.Animals.Mammals.Felines;
using Wild_Farm.Core.Food;

namespace Wild_Farm.Core
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            Console.WriteLine(this.FoodAskSound);
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public virtual List<string> WhatDoYouEat { get; set; } = new List<string>();
        public virtual string FoodAskSound { get; set; } = "";
        public virtual double WeightIncrease { get; set; } = 0;

        public virtual void Feed(Food.Food food,string type)
        {
            if (!WhatDoYouEat.Contains(type))
            {
                Console.WriteLine($"{type} does not eat {food}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight+=WeightIncrease;
            }
        }
        public override string ToString()
        {
            string type = this.GetType().DeclaringType.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append($"[{Name}");
            return sb.ToString().TrimEnd();
        }
    }
}
