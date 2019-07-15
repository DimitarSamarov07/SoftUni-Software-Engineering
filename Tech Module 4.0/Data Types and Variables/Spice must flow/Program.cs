using System;

namespace Spice_must_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int yield = 0;


            while (startingYield>=100)
            {

                yield += startingYield - 26;
                startingYield -= 10;
                days++;

            }
            if (yield>=26)
            {
                yield -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(yield);






        }
    }
}
