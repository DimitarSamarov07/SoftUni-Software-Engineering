using System;
using System.Text;
using MXGP.Core;
using MXGP.Models.Motorcycles.Classes;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ChampionshipController control = new ChampionshipController();
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] input = line.Split(" ");
                string command = input[0];
                string nameOrType = input[1];
                try
                {
                    if (command == "CreateRider")
                    {
                        Console.WriteLine(control.CreateRider(nameOrType));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string model = input[2];
                        int horsePower = int.Parse(input[3]);
                        Console.WriteLine(control.CreateMotorcycle(nameOrType,model,horsePower));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string riderName = input[2];
                        Console.WriteLine(control.AddRiderToRace(nameOrType,riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        int laps = int.Parse(input[2]);
                        Console.WriteLine(control.CreateRace(nameOrType,laps));
                    }
                    else if (command == "StartRace")
                    {
                        Console.WriteLine(control.StartRace(nameOrType));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string motoName = input[2];
                        Console.WriteLine(control.AddMotorcycleToRider(nameOrType,motoName));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Environment.Exit(0);
        }
    }
}
