using System;
using System.ComponentModel.Design;
using System.Text;
using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            MachinesManager manager = new MachinesManager();
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] line = input.Split(" ");
                string command = line[0];
                string name = line[1];
                try
                {
                    if (command == "HirePilot")
                    {
                        Console.WriteLine(manager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        Console.WriteLine(manager.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        double attackPoints = double.Parse(line[2]);
                        double defensePoints = double.Parse(line[3]);
                        Console.WriteLine(manager.ManufactureTank(name, attackPoints, defensePoints));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        double attackPoints = double.Parse(line[2]);
                        double defensePoints = double.Parse(line[3]);
                        Console.WriteLine(manager.ManufactureFighter(name, attackPoints, defensePoints));
                    }
                    else if (command=="MachineReport")
                    {
                        Console.WriteLine(manager.MachineReport(name));
                    }
                    else if (command=="AggressiveMode")
                    {
                        Console.WriteLine(manager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command=="DefenseMode")
                    {
                        Console.WriteLine(manager.ToggleTankDefenseMode(name));
                    }
                    else if (command=="Engage")
                    {
                        string pilotName = name;
                        string machineName = line[2];
                        Console.WriteLine(manager.EngageMachine(pilotName, machineName));
                    }
                    else if (command=="Attack")
                    {
                        string attacker = name;
                        string defender = line[2];
                        Console.WriteLine(manager.AttackMachines(attacker, defender));

                    }
                }
                catch (ArgumentNullException exc)
                {
                    Console.WriteLine("Error:"+exc.ParamName);
                    Environment.Exit(0);
                }
                
            }

        }
    }
}