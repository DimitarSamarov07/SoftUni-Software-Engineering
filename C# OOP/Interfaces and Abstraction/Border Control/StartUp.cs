using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Border_Control
{


    public class StartUp
    {
        public static List<string> IdsList;
        static void Main(string[] args)
        {
            string input=String.Empty;
            IdsList=new List<string>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (line.Length == 3)
                {
                    string name = line[0];
                    int age = int.Parse(line[1]);
                    string id = line[2];
                    ICitizen citizen = new Control(name, age, id);
                    IdsList.Add(citizen.Id);
                }

                else
                {
                    string model = line[0];
                    string id = line[1];
                    IRobot robot = new Control(model, id);
                    IdsList.Add(robot.Id);
                }
            }

            string fakeFilter = Console.ReadLine();
            Console.WriteLine(GetFakeIds(fakeFilter));
        }

        public static string GetFakeIds(string filter)
        {
            StringBuilder sb = new StringBuilder();
           List<string> fakes = IdsList.Where(x => x.EndsWith(filter)).ToList();
            foreach (string id in fakes)
            {
                if (id.EndsWith(filter))
                {
                    sb.Append(id);
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
