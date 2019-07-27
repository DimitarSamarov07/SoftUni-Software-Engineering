using System;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        public Animal(string name, int energy, int happiness, int produceTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProduceTime = produceTime;
            this.Owner = "Center";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }
        public string Name { get; set; }

        public int Happiness
        {
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                energy = value;
            }
        }

        public int ProduceTime { get; set; }
        public string Owner { get; set; }
        public bool IsAdopt { get; set; }
        public bool IsChipped { get; set; }
        public bool IsVaccinated { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"    Animal type: {this.GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}");
            return sb.ToString().TrimEnd();
        }
    }
}
