using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string dayoftheweek = Console.ReadLine();
            double sum = 0;

            if (type == "Business" && numberOfPeople >= 100)
            {
                numberOfPeople = numberOfPeople - 10;
            }

            if (type == "Business")
            {
                switch (dayoftheweek)
                {
                    case "Friday":
                        sum = numberOfPeople * 10.90;
                        break;
                    case "Saturday":
                        sum = numberOfPeople * 15.60;
                        break;
                    case "Sunday":
                        sum = numberOfPeople * 16;
                        break;

                    default:
                        return;
                }

            }
            if (type == "Students")
            {
                switch (dayoftheweek)
                {
                    case "Friday":
                        sum = numberOfPeople * 8.45;
                        break;
                    case "Saturday":
                        sum = numberOfPeople * 9.80;
                        break;
                    case "Sunday":
                        sum = numberOfPeople * 10.46;
                        break;

                    default:
                        return;
                }

            }

            if (type == "Regular")
            {
                switch (dayoftheweek)
                {
                    case "Friday":
                        sum = numberOfPeople * 15;
                        break;
                    case "Saturday":
                        sum = numberOfPeople * 20;
                        break;
                    case "Sunday":
                        sum = numberOfPeople * 22.50;
                        break;
                    default:
                        return;
                }
            }
            

            if (type == "Regular" && numberOfPeople >= 10 && numberOfPeople <= 20)
            {
                sum = sum - (sum * 0.5);
            }

            if (type == "Students" && numberOfPeople >= 30)
            {
                sum = sum *0.85;
            }
            Console.WriteLine($"Total price: {sum:f2}");

        }
    }
}
