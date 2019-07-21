using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core.Animals.Mammals.Felines
{
    public class Tiger:Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override string FoodAskSound { get; set; }="ROAR!!!";
        public override double WeightIncrease { get; set; } = 1;
        public override List<string> WhatDoYouEat { get; set; }=new List<string>{"Meat"};
    }
}
