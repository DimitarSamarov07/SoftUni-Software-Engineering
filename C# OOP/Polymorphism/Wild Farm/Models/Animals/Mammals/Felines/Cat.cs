using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core.Animals.Mammals.Felines
{
    public class Cat:Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override string FoodAskSound { get; set; }="Meow";
        public override double WeightIncrease { get; set; } = 0.3;
        public override List<string> WhatDoYouEat { get; set; }= new List<string>{"Meat","Vegetable"};
    }
}
