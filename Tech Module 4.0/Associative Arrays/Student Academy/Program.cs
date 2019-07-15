using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }

                else
                {
                    students[name].Add(grade);
                }
            }

            foreach (var kvp in students.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }

        }

    }
}