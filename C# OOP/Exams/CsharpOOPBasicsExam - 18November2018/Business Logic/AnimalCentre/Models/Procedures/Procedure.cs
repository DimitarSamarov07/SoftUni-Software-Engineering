using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            ProcedureHistory = new Dictionary<string, List<IAnimal>>();
        }
        protected Dictionary<string, List<IAnimal>> ProcedureHistory { get; set; }
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ProcedureHistory)
            {
                sb.AppendLine(item.Key);
                foreach (var animal in item.Value)
                {
                    sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
    }
}
