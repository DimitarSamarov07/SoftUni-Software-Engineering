using System;
using System.Text;
using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            string line;
            RestaurantController control = new RestaurantController();
            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] input = line.Split(" ");
                    string command = input[0];
                    if (command == "AddFood ")
                    {
                        Console.WriteLine(control.AddFood(input[1], input[2], decimal.Parse(input[3])));
                    }
                    else if (command == "AddDrink")
                    {
                        Console.WriteLine(control.AddDrink(input[1], input[2], int.Parse(input[3]), input[4]));
                    }
                    else if (command == "AddTable")
                    {
                        Console.WriteLine(control.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3])));
                    }
                    else if (command == "ReserveTable")
                    {
                        Console.WriteLine(control.ReserveTable(int.Parse(input[1])));
                    }
                    else if (command == "OrderFood")
                    {
                        Console.WriteLine(control.OrderFood(int.Parse(input[1]), input[2]));
                    }
                    else if (command == "OrderDrink")
                    {
                        Console.WriteLine(control.OrderDrink(int.Parse(input[1]), input[2], input[3]));
                    }
                    else if (command == "LeaveTable")
                    {
                        Console.WriteLine(control.LeaveTable(int.Parse(input[1])));
                    }
                    else if (command == "GetFreeTablesInfo")
                    {
                        Console.WriteLine(control.GetFreeTablesInfo());
                    }
                    else if (command == "GetOccupiedTablesInfo")
                    {
                        Console.WriteLine(control.GetOccupiedTablesInfo());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            Console.WriteLine(control.GetSummary());
        }
    }
}
