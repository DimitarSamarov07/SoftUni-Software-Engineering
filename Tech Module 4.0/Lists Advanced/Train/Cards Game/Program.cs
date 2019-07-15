using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int count = 0;
            List<int> copiedFirst = new List<int>();
            int sumOfFirst = 0;
            int SumOfSecond = 0;
            bool firstIsBigger = false;
            bool secondIsBigger = false;
            bool equality = false;
            foreach (var item in firstPlayer)
            {
                copiedFirst.Add(item);
                
            }
            foreach (var John in secondPlayer)
            {

                if (copiedFirst[count] > John)
                {
                    sumOfFirst = sumOfFirst + John + copiedFirst[count];
                }
                else if (John > copiedFirst[count])
                {
                    SumOfSecond = SumOfSecond + John + copiedFirst[count];
                }
                count++;
            }
            if (sumOfFirst > SumOfSecond)
            {
                firstIsBigger = true;
                secondIsBigger = false;
                equality = false;
            }

            if (SumOfSecond>sumOfFirst)
            {
                firstIsBigger = false;
                secondIsBigger = true;
                equality = false;
            }

            if (SumOfSecond==sumOfFirst)
            {
                firstIsBigger = false;
                secondIsBigger = false;
                equality = true;
            }
            if (firstIsBigger)
            {
                Console.WriteLine($"First player wins! Sum: {sumOfFirst}");
            }
            if (secondIsBigger)
            {
                Console.WriteLine($"Second player wins! Sum: {SumOfSecond}");
            }
            if (equality)
            {
                Console.WriteLine();
            }


        }
        
        
    }
}
