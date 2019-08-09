using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal,procedureTime);
            animal.Happiness -= 7;
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
