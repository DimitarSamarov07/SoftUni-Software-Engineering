using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Food_Shortage
{
    class StartUp
    {
        public static List<Citizen> Citizens;
        public static List<Rebel> Rebels;
        static void Main(string[] args)
        {
            Citizens = new List<Citizen>();
            Rebels = new List<Rebel>();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (line.Length == 4)
                {
                    string name = line[0];
                    int age = int.Parse(line[1]);
                    string id = line[2];
                    int[] birthDate = line[3].Replace("/"," ").Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    DateTime date = new DateTime(birthDate[2], birthDate[1], birthDate[0]);
                    Citizen citizen = new Citizen(name, age, id, date);
                    Citizens.Add(citizen);
                }
                else if (line.Length == 3)
                {
                    string name = line[0];
                    int age = int.Parse(line[1]);
                    string group = line[2];
                    Rebel rebel = new Rebel(name, age, group);
                    Rebels.Add(rebel);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (Citizens.Any(x => x.Name == input))
                {
                    List<Citizen> itemList = Citizens.Where(x => x.Name == input).ToList();
                    Citizen item = itemList[0];
                    int index = Citizens.IndexOf(item);
                    item.Food += 10;
                }
                else if(Rebels.Any(x=>x.Name==input))
                {
                    List<Rebel> itemList = Rebels.Where(x => x.Name == input).ToList();
                    Rebel item = itemList[0];
                    int index = Rebels.IndexOf(item);
                    item.Food += 5;
                }
               
            }

            Console.WriteLine(GetTotalFood());
        }

        private static string GetTotalFood()
        {
            int total = 0;
            foreach (var citizen in Citizens)
            {
                total += citizen.GetFoodAmount();
            }

            foreach (var rebel in Rebels)
            {
                total += rebel.GetFoodAmount();
            }

            return total.ToString().TrimEnd();
        }
    }
}
