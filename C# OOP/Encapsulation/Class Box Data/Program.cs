using System;

namespace Class_Box_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box newBox = new Box(length,width,height);
        }
    }
}
