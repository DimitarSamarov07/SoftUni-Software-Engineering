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

            string[] inputPeople = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] inputProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputPeople.Length; i++)
            {
                
                string[] peopleSplitter = inputPeople[i].Split("=").ToArray();
                string guyName = peopleSplitter[0];
                decimal guyValue = decimal.Parse(peopleSplitter[1]);
                Person toAddGuy = new Person(guyName, guyValue);
                guys.Add(toAddGuy);

            }
            for (int j = 0; j < inputProducts.Length; j++)
            {
                string[] productSplitter = inputProducts[j].Split("=").ToArray();
                string productName = productSplitter[0];
                decimal productValue = decimal.Parse(productSplitter[1]);
                Product toAddProd = new Product(productName,productValue);
                products.Add(toAddProd);
            }

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                if (line.ToUpper() == "END")
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

                if (money >= price)
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
                    Console.WriteLine($"{guy.Name} - {String.Join(", ", guy.BagOfProducts)}");
                }

                else
                {
                    Console.WriteLine($"{guy.Name} - Nothing bought");
                }
            }
        }
    }
}
