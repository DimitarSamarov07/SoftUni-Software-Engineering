using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        throw new ArgumentException("Name cannot be empty");
                    }
                    catch (Exception e)
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

        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value<0)
                {
                    try
                    {
                        throw new ArgumentException("Money cannot be negative");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(0);
                    }
                }

                else
                {
                    cost = value;
                }
            } 

        }

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
