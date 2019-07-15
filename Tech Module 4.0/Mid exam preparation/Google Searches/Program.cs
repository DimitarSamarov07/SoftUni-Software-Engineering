using System;

namespace Google_Searches
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int numberOfUsers = int.Parse(Console.ReadLine());
            double earningsPerSearch = double.Parse(Console.ReadLine());
            int wordLenght = 0;
            double sum = 0;

            for (int currentUser = 1; currentUser <= numberOfUsers; currentUser++)
            {
                double currentSum = 0;
                wordLenght = int.Parse(Console.ReadLine());

                if (wordLenght <= 5)
                {

                    if (wordLenght == 1)
                    {
                        currentSum += earningsPerSearch * 2;
                    }

                    else
                    {
                        currentSum += earningsPerSearch;
                    }
                }
                if (currentUser % 3 == 0)
                {
                    currentSum = currentSum * 3;

                }
                sum += currentSum;
            }
            sum *= days;
            Console.WriteLine($"Total money earned for {days} days: {sum:f2}");

        }
    }
}
