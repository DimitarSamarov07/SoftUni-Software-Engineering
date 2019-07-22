using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override string FoodAskSound { get; set; } = "Squeak";
        public override double WeightIncrease { get; set; } = 0.1;
        public override List<string> WhatDoYouEat { get; set; }= new List<string>{"Fruit","Vegetable"};
    }
}
