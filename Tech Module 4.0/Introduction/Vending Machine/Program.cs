using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal totalMoney = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Start")
                {
                    break;
                }

                decimal coin = decimal.Parse(input);

                if (coin == 0.1m || coin == 0.2m || coin == 0.5m || coin == 1m || coin == 2m)
                {
                    totalMoney += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                //“Nuts”, “Water”, “Crisps”, “Soda”, “Coke”.
                // 2.0, 0.7, 1.5, 0.8, 1.0
                if (input == "End")
                {
                    break;
                }


                if (input == "Nuts")
                {
                    if (totalMoney >= 2.0m)
                    {
                        totalMoney -= 2.0m;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Water")
                {
                    if (totalMoney >= 0.7m)
                    {
                        totalMoney -= 0.7m;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (totalMoney >= 1.5m)
                    {
                        totalMoney -= 1.5m;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (totalMoney >= 0.8m)
                    {
                        totalMoney -= 0.8m;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (totalMoney >= 1.0m)
                    {
                        totalMoney -= 1.0m;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }

            Console.WriteLine($"Change: {totalMoney:F2}");

        }

    }

}
