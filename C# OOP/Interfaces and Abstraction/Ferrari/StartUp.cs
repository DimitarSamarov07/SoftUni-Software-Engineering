using System;

namespace Ferrari
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();
            ICar ferrari = new Ferrari(driverName);

            Console.WriteLine($"{ferrari.Model}/{ferrari.Brake()}/{ferrari.Gas()}/{ferrari.Driver}");
        }
    }
}
