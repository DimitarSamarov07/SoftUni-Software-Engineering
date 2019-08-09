using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Pig:Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"    Animal type: Pig - {Name} - Happiness: {Happiness} - Energy: {Energy}");
            return sb.ToString().TrimEnd();
        }
    }
}
