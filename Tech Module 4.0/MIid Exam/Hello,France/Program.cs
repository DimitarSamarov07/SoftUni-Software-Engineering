using System;
using System.Collections.Generic;
using System.Linq;

namespace Hello_France
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|").ToList();
            double budget = double.Parse(Console.ReadLine());
            double profit = 0;
            int priceNumber = 0;
            double spendedMoney = 0;
            double sold = 0;
            double newBudget = 0;
            List<double> priceList = new List<double>();


            for (int current = 0; current < input.Count; current++)
            {
                List<string> details = input[current].Split("->").ToList();  
                string type = details[0];
                double price = double.Parse(details[1]);
                string priceString = price.ToString();
                
                
                if (type == "Clothes")
                {
                    if (price>budget)
                    {
                        continue;
                    }

                    else if (price<=budget)
                    {
                        if (price>50.00)
                        {
                            continue;
                        }
                        else if (price>budget)
                        {
                            continue;
                        }
                        else if (price<=budget)
                        {
                            budget -= price;
                            priceList.Add(price + (price * 0.4));
                            spendedMoney += price;
                            sold+= price + (price * 0.4);
                            priceNumber++;
                            continue;
                        }
                    }
                }
                else if (type == "Shoes")
                {

                    if (price > budget)
                    {
                        continue;
                    }

                    else if (price <= budget)
                    {
                        if (price > 35.00)
                        {
                            continue;
                        }
                        else if (price > budget)
                        {
                            continue;
                        }
                        else if (price <= budget)
                        {
                            budget -= price;                          
                            priceList.Add(price + (price * 0.4));
                            sold += price + (price * 0.4);
                            spendedMoney += price;
                            priceNumber++;

                            continue;
                        }
                    }
                }
                else if (type == "Accessories")
                {

                    if (price > budget)
                    {
                        continue;
                    }

                    else if (price <= budget)
                    {
                        if (price > 20.50)
                        {
                            continue;
                        }
                        else if (price > budget)
                        {
                            continue;
                        }
                        else if (price <= budget)
                        {
                            budget -= price;
                            priceList.Add(price + (price * 0.4));
                            sold += price + (price * 0.4);
                            spendedMoney += price;
                            priceNumber++;
                            continue;
                        }
                    }
                }
            }
            profit = sold - spendedMoney;
            for (int i = 0; i < priceNumber; i++)
            {
                Console.Write($"{priceList[i]:f2}"+" ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");
            newBudget = budget;
            for (int i = 0; i < priceList.Count; i++)
            {
                newBudget += priceList[i];
            }
            

            if (newBudget>=125)
            {
                Console.WriteLine("Hello, France!");
            }
            else if (newBudget<125)
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
