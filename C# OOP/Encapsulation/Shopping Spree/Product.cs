using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Product
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ArgumentException pesho = new ArgumentException("name");
                }

                else
                {
                    name = value;
                }
            }

        }
        public double Cost { get; set; }

        public Product(string name,double cost)
        {
            if (name==null)
            {
               ArgumentException pesho = new ArgumentException("name");
            }
            this.Name = name;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
