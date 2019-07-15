using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string peakPattern = @"[a-zA-Z!@#$?]+(?==)";
            string geohashPattern = @"(?<=<<)[a-z0-9]+";
            string geohashLenghthPattern = @"[0-9]+(?=<)";
            bool IsMatch1 = Regex.IsMatch(line, peakPattern);
            bool IsMatch2 = Regex.IsMatch(line, geohashLenghthPattern);
            bool IsMatch3 = Regex.IsMatch(line, geohashPattern);
            String check = Regex.Match(line, peakPattern);
            string checksth = Regex.Match(line, geohashLenghthPattern).ToString();
            int checksthint = int.Parse(checksth);
            
            if (IsMatch1&&IsMatch2&&IsMatch3&&checksthint==check.Length)
            {
                Console.WriteLine("hello");
            }
            else
            {
                Console.WriteLine("Nothing found!");
                return;
            }

        }
    }
}
