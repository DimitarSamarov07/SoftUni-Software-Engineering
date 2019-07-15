using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                List<string> info = cmd.Split(" : ").ToList();
                string courseName = info[0];
                string studentName = info[1];


                if (!courses.ContainsKey(courseName))
                {
                    var students = new List<string>
                    {
                        studentName
                    };
                    courses.Add(courseName, students);

                }
                else
                {
                    courses[courseName].Add(studentName);
                }

            }
            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                var orderStudents = item.Value.OrderBy(x => x).ToList();
                foreach (var student in orderStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}