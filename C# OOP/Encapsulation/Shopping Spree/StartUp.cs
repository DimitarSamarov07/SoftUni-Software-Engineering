using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Shopping_Spree
{
    public class StartUp
    {
        
        static void Main(string[] args)
        { 
            List<Person> guys = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(";",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    string[] splitter = input[j].Split("=").ToArray();
                    string name = splitter[0];
                    decimal value = decimal.Parse(splitter[1]);
                    if (i == 0)
                    {
                        Person toAdd = new Person(name, value);
                        guys.Add(toAdd);
                    }

                    else
                    {
                        Product toAdd = new Product(name,value);
                        products.Add(toAdd);
                    }
                }
            }
            string line;
            while ((line=Console.ReadLine())!="END")
            {
                if (line.ToUpper()=="END")
                {
                    break;
                }
                string[] input = line
                    .Split(" ")
                    .ToArray();
                string personName = input[0];
                string productName = input[1];
                Person currentPerson = guys.FirstOrDefault(x => x.Name == personName);
                Product currentProduct = products.FirstOrDefault(x => x.Name == productName);
                decimal price = currentProduct.Cost;
                decimal money = currentPerson.Money;

                if (money>=price)
                {
                    currentPerson.Money -= price;
                    currentPerson.BagOfProducts.Add(currentProduct);
                    Console.WriteLine($"{personName} bought {productName}");
                }

                else
                {
                    try
                    {
                        throw new ArgumentException($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                }
            }

            foreach (var guy in guys)
            {
                if (guy.BagOfProducts.Any())
                {
                    Console.WriteLine($"{guy.Name} - {String.Join(", ",guy.BagOfProducts)}");
                }

                else
                {
                    Console.WriteLine($"{guy.Name} - Nothing bought");
                }
            }
        }
    }
}
