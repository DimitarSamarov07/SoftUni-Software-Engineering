using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override string FoodAskSound { get; set; } = "Woof!";
        public override double WeightIncrease { get; set; } = 0.4;
        public override List<string> WhatDoYouEat { get; set; }= new List<string>{"Meat"};
    }
}
