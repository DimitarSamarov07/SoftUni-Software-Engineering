using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringAndRegex
{
    class Program
    {
        static void Main()
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$";

            string input = String.Empty;
            double totalIncome = 0.0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Regex order = new Regex(pattern);

                if (order.IsMatch(input))
                {

                    string customerName = order.Match(input).Groups["customer"].Value;
                    string productName = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = price * count;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:F2}");

                }

            }

            Console.WriteLine($"Total income: {totalIncome:F2}");

        }
    }
}