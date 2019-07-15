using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Pizza_Calories
{
    public class Topping
    {
        private double toppingValue;
        //MODIFIERS
        private const double Meat = 1.2*2;
        private const double Veggies = 0.8*2;
        private const double Cheese = 1.1*2;
        private const double Sauce = 0.9*2;
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            SetTopping(toppingType);
            this.Grams = grams;
        }

        

        private double Grams
        {
            get => grams;
            set
            {
                if (value>=1&&value<=50)
                {
                    grams = value;
                }

                else
                {
                    try
                    {
                        throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(0);
                    }
                   
                }
            }
        }

        public  double TotalCalories => Grams * ToppingValue;
        private string ToppingType
        {
            get => toppingType;
            set { toppingType = value; }
        }
        private double ToppingValue
        {
            get => toppingValue;
            set { toppingValue = value; }
        }
        private void SetTopping(string topping)
        {
            double valueToSet = 0;
            string lowerTopping = topping.ToLower();
            if (lowerTopping=="meat")
            {
                valueToSet = Meat;
            }
            else if (lowerTopping=="veggies")
            {
                valueToSet = Veggies;
            }
            else if (lowerTopping=="cheese")
            {
                valueToSet = Cheese;
            }
            else if (lowerTopping=="sauce")
            {
                valueToSet = Sauce;
            }
            else
            {
                try
                {
                    throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            ToppingValue = valueToSet;

        }
    }
}
