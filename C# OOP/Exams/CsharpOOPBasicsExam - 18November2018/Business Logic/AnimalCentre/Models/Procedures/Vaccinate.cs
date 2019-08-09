using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal,procedureTime);
            animal.Energy -= 8;
            animal.IsVaccinated = true;
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
