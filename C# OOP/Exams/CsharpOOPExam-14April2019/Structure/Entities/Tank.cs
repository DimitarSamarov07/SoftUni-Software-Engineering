using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints -= 40, defensePoints += 30, 100)
        {
        }

        public bool DefenseMode { get; private set; } = true;
        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
            else
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            string state = String.Empty;
            state = DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {state}";
        }
    }
}
