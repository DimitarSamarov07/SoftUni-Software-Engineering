using System;

namespace Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodExpenses = double.Parse(Console.ReadLine());
            int priceOfRoomForNight = int.Parse(Console.ReadLine());
            double distance = 0;
            double expenses = priceOfRoomForNight * people * days;
            if (people > 10)
            {
                expenses -= 0.25 * expenses;
            }
            expenses += foodExpenses * people*days;



            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                distance = int.Parse(Console.ReadLine());
                expenses += (distance * fuelPerKm);

                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses - budget:f2}$ more.");
                    return;
                }
                if (currentDay % 3 == 0)
                {
                    expenses = expenses + (expenses * 0.4);
                }

                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses - budget:f2}$ more.");
                    return;
                }
                if (currentDay % 5 == 0)
                {
                    expenses = expenses + (expenses * 0.4);
                }

                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses - budget:f2}$ more.");
                    return;
                }
                if (currentDay % 7 == 0)
                {
                    expenses -= expenses/people;

                }

                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses - budget:f2}$ more.");
                    return;
                }
            }
            double money = budget - expenses;
            Console.WriteLine($"You have reached the destination. You have {money:f2}$ budget left.");
        }
    }
}
