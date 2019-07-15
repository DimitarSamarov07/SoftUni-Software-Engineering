using System;

namespace Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeday = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double sum = 0;

            while (true)
            {
                if (typeday == "Weekday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        sum = sum + 12;
                        Console.WriteLine($"{sum}$");
                        return;

                    }

                    if (age >= 18 && age <= 64)
                    {
                        sum = sum + 18;
                        Console.WriteLine($"{sum}$");
                        return;
                    }

                    if (age > 64 && age <= 122)
                    {
                        sum = sum + 12;
                        Console.WriteLine($"{sum}$");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }

                if (typeday == "Weekend")
                {
                    if (age >= 0 && age <= 18)
                    {
                        sum = sum + 15;
                        Console.WriteLine($"{sum}$");
                        return;
                    }

                    if (age >= 18 && age <= 64)
                    {
                        sum = sum + 20;
                        Console.WriteLine($"{sum}$");
                        return;
                    }

                    if (age > 64 && age <= 122)
                    {
                        sum = sum + 15;
                        Console.WriteLine($"{sum}$");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                if (typeday == "Holiday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        sum = sum + 5;
                        Console.WriteLine($"{sum}$");
                        return;
                    }

                    if (age >= 18 && age <= 64)
                    {
                        sum = sum + 12;
                        Console.WriteLine($"{sum}$");
                        return;
                    }

                    if (age > 64 && age <= 122)
                    {
                        sum = sum + 10;
                        Console.WriteLine($"{sum}$");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }

                else
                {
                    Console.WriteLine("Error!");
                }

            }





        }
    }
}
