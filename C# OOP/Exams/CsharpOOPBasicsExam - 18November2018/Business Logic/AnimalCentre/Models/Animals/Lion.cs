using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Lion:Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"    Animal type: Lion - {Name} - Happiness: {Happiness} - Energy: {Energy}");
            return sb.ToString().TrimEnd();
        }
    }
}
