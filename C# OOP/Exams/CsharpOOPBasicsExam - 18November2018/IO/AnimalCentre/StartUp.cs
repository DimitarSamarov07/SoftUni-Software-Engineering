
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string line;
            StringBuilder sb = new StringBuilder();
            Core.AnimalCentre control = new Core.AnimalCentre();
            Dictionary<string, List<string>> ownersAndTheirAnimals = new Dictionary<string, List<string>>();
            while ((line = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] input = line.Split(" ");
                    string command = input[0];
                    string typeOrName = input[1];
                    if (command == "RegisterAnimal")
                    {
                        sb.AppendLine(control.RegisterAnimal(typeOrName, input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                    }
                    else if (command == "Chip")
                    {
                        sb.AppendLine(control.Chip(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "Vaccinate")
                    {
                        sb.AppendLine(control.Vaccinate(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "Fitness")
                    {
                        sb.AppendLine(control.Fitness(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "Play")
                    {
                        sb.AppendLine(control.Play(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "DentalCare")
                    {
                        sb.AppendLine(control.DentalCare(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "NailTrim")
                    {
                        sb.AppendLine(control.NailTrim(typeOrName, int.Parse(input[2])));
                    }
                    else if (command == "Adopt")
                    {
                        sb.AppendLine(control.Adopt(typeOrName, input[2]));
                        if (!ownersAndTheirAnimals.ContainsKey(input[2]))
                        {
                            ownersAndTheirAnimals.Add(input[2], new List<string>());
                            ownersAndTheirAnimals[input[2]].Add(typeOrName);
                        }
                        else
                        {
                            ownersAndTheirAnimals[input[2]].Add(typeOrName);
                        }
                    }
                    else if (command == "History")
                    {
                        sb.Append(control.History(typeOrName));
                    }
                }
                catch (InvalidOperationException e)
                {
                    sb.AppendLine($"InvalidOperationException: {e.Message}");
                }
                catch (ArgumentException e)
                {
                    sb.AppendLine($"ArgumentException: {e.Message}");
                }
            }

            Console.Write(sb);
            foreach (var item in ownersAndTheirAnimals.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"--Owner: {item.Key}");
                Console.WriteLine($"    - Adopted animals: {String.Join(" ", item.Value)}");
            }

        }
    }
}
