using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }
        public double AttackPoints { get; set; }
        public double DefensePoints { get;  set; }
        public IList<string> Targets { get; set; }
        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= AttackPoints - target.DefensePoints;
            if (target.HealthPoints < 0)
            {
                HealthPoints = 0;
            }
            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {HealthPoints:f2}")
                .AppendLine($" *Attack: {AttackPoints:f2}")
                .AppendLine($" *Defense: {DefensePoints:f2}");
            if (Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {String.Join(",", Targets)}");
            }
            else
            {
                sb.AppendLine($" *Targets: None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
