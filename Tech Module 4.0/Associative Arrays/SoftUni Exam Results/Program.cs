using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {

            var studentsAndPoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputLine = input.Split("-");
                string name = inputLine[0];

                if (inputLine[1]=="banned")
                {
                    studentsAndPoints.Remove(name);
                }

                else
                {
                    string language = inputLine[1];
                    int points = int.Parse(inputLine[2]);

                    if (!studentsAndPoints.ContainsKey(name))
                    {
                        studentsAndPoints[name] = points;
                    }

                    else if(points>studentsAndPoints[name])
                    {
                        studentsAndPoints[name] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }

                    submissions[language]++;
                }
            }
            Console.WriteLine("Results:");
            foreach (var kvp in studentsAndPoints
                .OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)) 
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
            
        }
    }
}
