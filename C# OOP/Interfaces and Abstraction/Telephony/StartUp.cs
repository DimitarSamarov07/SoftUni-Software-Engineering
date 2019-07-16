using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numberList = Console.ReadLine()
                .Split(" ")
                .ToList();
            List<string> urListList = Console.ReadLine()
                .Split(" ")
                .ToList();
            ICallable callMe = new Smartphone(numberList,urListList);
            IBrowseable browseMe = new Smartphone(numberList,urListList);
            Console.WriteLine(callMe.Call());
            Console.WriteLine(browseMe.Browse());
        }
    }
}
