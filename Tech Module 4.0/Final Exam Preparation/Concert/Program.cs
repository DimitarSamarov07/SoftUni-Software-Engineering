using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] splitter = new char[] { ':', ';' };
            string inputLine = Console.ReadLine();
            List<string> list = inputLine.Split(new string[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();



        }
    }
}
