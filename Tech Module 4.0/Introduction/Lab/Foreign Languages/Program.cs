using System;

namespace Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            if (country == "England" || country == "USA")
            {
                Console.WriteLine("English");
                return;
            }

            if (country == "Spain" || country == "Argentina" || country == "Mexico")
            {
                Console.WriteLine("Spanish");
                return;
            }
            else
            {
                Console.WriteLine("unknown");
            }


        }
    }
}
