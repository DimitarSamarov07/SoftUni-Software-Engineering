using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NewSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    var line = input.Split(" -> ").ToArray();

                    var companyName = line[0];
                    var employer = line[1];

                    if (!companies.ContainsKey(companyName))
                    {
                        companies.Add(companyName, new List<string>());
                        companies[companyName].Add(employer);
                    }
                    else if (!companies[companyName].Contains(employer))
                    {
                        companies[companyName].Add(employer);
                    }
                }
            }
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}