using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name,decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts= new List<Product>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        throw new ArgumentException("Name cannot be empty");
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

        public decimal Money
        {
            get
            {
                return money; 

            }
            set
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
                    money = value;
                }
            }
        }

        public List<Product> BagOfProducts { get; private set; }
    }
}
