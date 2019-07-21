using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core.Animals.Birds
{
    public class Owl:Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override string FoodAskSound { get; set; }="Hoot Hoot";
        public override double WeightIncrease { get; set; } = 0.25;
        public override List<string> WhatDoYouEat { get; set; }= new List<string>{"Meat"};
    }
}
