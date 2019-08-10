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
                    string[] input = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    string command = input[0];
                    if (command == "AddFood")
                    {
                        string type = input[1];
                        string name = input[2];
                        decimal price = decimal.Parse(input[3]);
                        Console.WriteLine(control.AddFood(type, name, price));
                    }
                    else if (command == "AddDrink")
                    {
                        string type = input[1];
                        string name = input[2];
                        int servingSize = int.Parse(input[3]);
                        string brand = input[4];
                        Console.WriteLine(control.AddDrink(type,name,servingSize,brand));
                    }
                    else if (command == "AddTable")
                    {
                        string type = input[1];
                        int tableNumber = int.Parse(input[2]);
                        int capacity = int.Parse(input[3]);
                        Console.WriteLine(control.AddTable(type, tableNumber, capacity));
                    }
                    else if (command == "ReserveTable")
                    {
                        int numberOfPeople = int.Parse(input[1]);
                        Console.WriteLine(control.ReserveTable(numberOfPeople));
                    }
                    else if (command == "OrderFood")
                    {
                        int tableNumber = int.Parse(input[1]);
                        string foodName = input[2];
                        Console.WriteLine(control.OrderFood(tableNumber,foodName));
                    }
                    else if (command == "OrderDrink")
                    {
                        int tableNumber = int.Parse(input[1]);
                        string drinkName = input[2];
                        string drinkBrand = input[3];
                        Console.WriteLine(control.OrderDrink(tableNumber,drinkName,drinkBrand));
                    }
                    else if (command == "LeaveTable")
                    {
                        int tableNumber = int.Parse(input[1]);
                        Console.WriteLine(control.LeaveTable(tableNumber));
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
