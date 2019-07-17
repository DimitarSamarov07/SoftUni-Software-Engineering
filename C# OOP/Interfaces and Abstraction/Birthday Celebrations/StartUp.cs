using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Birthday_Celebrations
{


    public class StartUp
    {
        public static List<ICitizen> Citizens;
        public static List<IRobot> Robots;
        public static List<IPet> Pets;
        public static List<DateTime> BirthDates;
        static void Main(string[] args)
        {
            string input = String.Empty;
            Citizens = new List<ICitizen>();
            Robots = new List<IRobot>();
            Pets = new List<IPet>();
            BirthDates = new List<DateTime>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = line[0];
                if (type == "Citizen")
                {
                    string name = line[1];
                    int age = int.Parse(line[2]);
                    string id = line[3];
                    string birthdate = line[4];
                    int[] date = birthdate.Split("/").Select(int.Parse).ToArray();
                    DateTime birthDate = new DateTime(date[2], date[1], date[0]);
                    ICitizen citizen = new Control(name, age, id, birthDate);
                    Citizens.Add(citizen);
                    BirthDates.Add(birthDate);
                }

                else if (type == "Robot")
                {
                    string model = line[1];
                    string id = line[2];
                    IRobot robot = new Control(model, id);
                    Robots.Add(robot);
                }

                else if (type == "Pet")
                {
                    string name = line[1];
                    string birthdate = line[2];
                    int[] date = birthdate.Split("/").Select(int.Parse).ToArray();
                    DateTime birthDate = new DateTime(date[2], date[1], date[0]);
                    IPet pet = new Control(name, birthDate);
                    Pets.Add(pet);
                    BirthDates.Add(birthDate);
                }
            }

            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBirthdatesInYear(year));
        }

        public static string GetBirthdatesInYear(int year)
        {
            StringBuilder sb = new StringBuilder();
            List<DateTime> dates = BirthDates.Where(x => x.Year == year).ToList();
            foreach (DateTime date in dates)
            {
                string dateString = date.ToString("dd/MM/yyyy");
                dateString=dateString.Replace(".", "/");
                sb.Append(dateString);
                sb.Append(Environment.NewLine);

            }

            return sb.ToString().TrimEnd();
        }
    }
}
