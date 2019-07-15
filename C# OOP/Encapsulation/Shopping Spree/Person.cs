using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name,double money)
        {
            if (name==null)
            {
                ArgumentException ex = new ArgumentException("name");
            }
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
                    ArgumentException ex = new ArgumentException("name");
                }

                else
                {
                    name = value;
                }
            }
        }

        public double Money
        {
            get
            {
                return money; 

            }
            set
            {
                if (value<0)
                {
                    ArgumentException ex = new ArgumentException("money");
                }

                else
                {
                    money = value;
                }
            }
        }

        public List<Product> BagOfProducts { get; set; }
    }
}
