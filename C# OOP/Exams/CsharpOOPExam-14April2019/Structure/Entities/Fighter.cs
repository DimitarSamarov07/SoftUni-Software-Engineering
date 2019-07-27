using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints += 50, defensePoints -= 25, 200)
        {
        }

        public bool AggressiveMode { get; set; } = true;
        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }

            else
            {
                AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            string state = String.Empty;
            if (AggressiveMode)
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Aggressive: {state}";
        }
    }
}
