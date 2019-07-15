using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> THELIST = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                List<string> Event = Console.ReadLine().Split().ToList();
                string command = Event[0];
                if (command=="end")
                {
                    break;
                }
                string element = Event[1];
                int elementParse = int.Parse(element);
                
                if (command=="Delete")
                {
                    THELIST.RemoveAll(item => item == elementParse);
                }
                else if (command=="Insert")
                {
                    int index = int.Parse(Event[2]);
                    THELIST.Insert(index, elementParse);
                }



            }
            Console.WriteLine(String.Join(" ",THELIST));
        }
    }
}
