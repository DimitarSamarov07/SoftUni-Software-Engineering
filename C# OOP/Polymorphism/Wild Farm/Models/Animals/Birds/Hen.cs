using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Core.Food;

namespace Wild_Farm.Core.Animals.Birds
{
    public class Hen:Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override string FoodAskSound { get; set; } = "Cluck";
        public override double WeightIncrease { get; set; } = 0.35;
        public override List<string> WhatDoYouEat { get; set; }= new List<string>{"Vegetable","Seeds","Meat","Fruit"};
    }
}
