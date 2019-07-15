using System;

namespace Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfpacketFlour = double.Parse(Console.ReadLine());
            double priceOfSingleEgg = double.Parse(Console.ReadLine());
            double priceOfSingleApron = double.Parse(Console.ReadLine());
            double priceOfFloor = priceOfpacketFlour * students;
            double priceOfEggs = priceOfSingleEgg * 10 * students;
            double studentsPercent = Math.Ceiling(students + students * 0.2);
            double priceOfaprons = priceOfSingleApron *  studentsPercent;
            if (students >= 5)
            {
                double discountForFloor = 0;
                discountForFloor = students / 5;
                priceOfFloor = priceOfFloor - (discountForFloor * priceOfpacketFlour);

            }
            double price = priceOfaprons + priceOfEggs + priceOfFloor;
            

            
            if (price<=budget)
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
