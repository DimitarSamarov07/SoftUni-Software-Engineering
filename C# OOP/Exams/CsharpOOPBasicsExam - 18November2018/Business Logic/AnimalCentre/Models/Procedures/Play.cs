using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal,procedureTime);
            animal.Energy -= 6;
            animal.Happiness += 12;
            if (!ProcedureHistory.ContainsKey(this.GetType().Name))
            {
                ProcedureHistory.Add(this.GetType().Name,new List<IAnimal>());
                ProcedureHistory[this.GetType().Name].Add(animal);
            }
            else
            {
                ProcedureHistory[this.GetType().Name].Add(animal);
            }
        }
    }
}
