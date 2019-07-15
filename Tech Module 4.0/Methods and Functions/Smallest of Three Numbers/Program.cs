using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main (string[] args)
        {
            
            int numberFirst = int.Parse(Console.ReadLine());
            int numberSecond = int.Parse(Console.ReadLine());
            int numberThird = int.Parse(Console.ReadLine());

           int answer= Math.Min(Math.Min(numberFirst,numberSecond),numberThird);
            Console.WriteLine(answer);
            return;


        }
    }
}
