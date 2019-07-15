using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Restaurant.Food.Starter
{
    public class Soup:Starter
    {
        public Soup(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
}
