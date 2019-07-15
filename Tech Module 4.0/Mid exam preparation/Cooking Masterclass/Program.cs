using System;

namespace Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlourPerPackage = double.Parse(Console.ReadLine());
            double priceOfSingleEgg = double.Parse(Console.ReadLine());
            double priceOfSingleApron = double.Parse(Console.ReadLine());
            double aprons = Math.Ceiling(students + (students * 0.2)) * priceOfSingleApron;
            double eggs = priceOfSingleEgg * 10 * students;
            double floor = priceOfFlourPerPackage * students;
            if (students >= 5)
            {
                floor -= (students / 5) * priceOfFlourPerPackage;
            }
            double price = aprons + eggs + floor;
            if (price <= budget)
            {
                Console.WriteLine($"Items purchased for {price:f2}$.");
            }
            else
            {
                Console.WriteLine($"{price - budget:f2}$ more needed.");
            }
        }
    }
}
