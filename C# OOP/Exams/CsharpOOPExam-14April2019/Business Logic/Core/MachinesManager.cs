using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using MortalEngines.Common;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        public MachinesManager()
        {
            this.Pilots = new List<IPilot>();
            this.Machines = new List<IMachine>();
        }

        private List<IPilot> Pilots { get; }
        private List<IMachine> Machines { get; }
        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);
            if (!Pilots.Contains(pilot))
            {
                Pilots.Add(pilot);
                return String.Format(OutputMessages.PilotHired, name);
            }
            return String.Format(OutputMessages.PilotExists, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            ITank toAdd = new Tank(name, attackPoints, defensePoints);
            if (Machines.Any(m => m.Name == name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }
            Machines.Add(toAdd);
            return String.Format(OutputMessages.TankManufactured, name, toAdd.AttackPoints, toAdd.DefensePoints);

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            if (Machines.All(m => m.Name != name))
            {
                Machines.Add(fighter);
                return String.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
            }
            return String.Format(OutputMessages.MachineExists, name);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (Pilots.All(x => x.Name != selectedPilotName))
            {
                return String.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (Machines.All(x => x.Name != selectedMachineName))
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            IMachine machine = Machines.FirstOrDefault(x => x.Name == selectedMachineName);
            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            if (machine.Pilot != null)
            {
                return String.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            IPilot pilot = Pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            if (pilot == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedPilotName);
            }
            pilot.AddMachine(machine);
            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = Machines.FirstOrDefault(m => m.Name == attackingMachineName);
            if (attacker == null)
            {
                return String.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            IMachine defender = Machines.FirstOrDefault(m => m.Name == defendingMachineName);
            if (defender == null)
            {
                return String.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            if (attacker.HealthPoints <= 0 || defender.HealthPoints <= 0)
            {
                if (attacker.HealthPoints <= 0)
                {
                    return String.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
                }

                if (defender.HealthPoints <= 0)
                {
                    return String.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
                }
            }
            attacker.Attack(defender);
            return String.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName,
                defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            if (Pilots.Any(p => p.Name == pilotReporting))
            {
                IPilot current = Pilots.FirstOrDefault(x => x.Name == pilotReporting);
                if (current == null)
                {
                    return String.Format(OutputMessages.PilotNotFound, pilotReporting);
                }
                return current.Report();
            }

            return String.Format(OutputMessages.PilotNotFound, pilotReporting);
        }

        public string MachineReport(string machineName)
        {
            IMachine current = Machines.FirstOrDefault(m => m.Name == machineName);
            if (current==null)
            {
                return String.Format(OutputMessages.MachineNotFound,machineName);
            }
            return current.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (Machines.Any(m => m.Name == fighterName))
            {
                foreach (IFighter machine in Machines.Where(m => m.GetType() == typeof(Fighter)).Where(m => m.Name == fighterName))
                {
                    machine.ToggleAggressiveMode();
                }
                return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
            return String.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (Machines.Any(m => m.Name == tankName))
            {
                foreach (ITank machine in Machines.Where(x => x.GetType() == typeof(Tank)).Where(x => x.Name == tankName))
                {
                    machine.ToggleDefenseMode();
                }
                return String.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return String.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}