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
            StringBuilder sb = new StringBuilder();
            RestaurantController control = new RestaurantController();
            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] input = line.Split(" ");
                    string command = input[0];
                    if (command == "AddFood")
                    {
                        sb.AppendLine(control.AddFood(input[1], input[2], decimal.Parse(input[3])));
                    }
                    else if (command == "AddDrink")
                    {
                        sb.AppendLine(control.AddDrink(input[1], input[2], int.Parse(input[3]), input[4]));
                    }
                    else if (command == "AddTable")
                    {
                        sb.AppendLine(control.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3])));
                    }
                    else if (command == "ReserveTable")
                    {
                        sb.AppendLine(control.ReserveTable(int.Parse(input[1])));
                    }
                    else if (command == "OrderFood")
                    {
                        sb.AppendLine(control.OrderFood(int.Parse(input[1]), input[2]));
                    }
                    else if (command == "OrderDrink")
                    {
                        sb.AppendLine(control.OrderDrink(int.Parse(input[1]), input[2], input[3]));
                    }
                    else if (command == "LeaveTable")
                    {
                        sb.AppendLine(control.LeaveTable(int.Parse(input[1])));
                    }
                    else if (command == "GetFreeTablesInfo")
                    {
                        sb.AppendLine(control.GetFreeTablesInfo());
                    }
                    else if (command == "GetOccupiedTablesInfo")
                    {
                        sb.AppendLine(control.GetOccupiedTablesInfo());
                    }
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.Message);
                }
                
            }

            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine(control.GetSummary());
        }
    }
}
