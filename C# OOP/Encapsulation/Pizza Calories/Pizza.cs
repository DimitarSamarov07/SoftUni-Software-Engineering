using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            if (name==null)
            {
                try
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            this.Name = name;
            this.Toppings=new List<Topping>();
        }

        

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<1||value.Length>15)
                {
                    try
                    {
                        throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(0);
                    }
                    
                }

                else
                {
                    name = value;
                }
            }
        }
        private List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }
        private Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        
        public void AddTopping(Topping topping)
        {
            if (Toppings.Count>10)
            {
                try
                {
                    throw new ArgumentException($"Number of toppings should be in range [0..10].");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            Toppings.Add(topping);
        }

        public void SetDough(Dough dough) => this.Dough = dough;

        public double GetTotalCalories()
        {
            double total = Dough.TotalCalories;
            if (Toppings.Any())
            {
                foreach (var topping in Toppings)
                {
                    total += topping.TotalCalories;
                }
            }
            

            return total;
        }
    }
}
