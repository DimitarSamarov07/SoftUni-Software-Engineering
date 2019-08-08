using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        public Hotel()
        {
            Animals = new List<IAnimal>();
        }
        private const int CAPACITY = 10;
        public int Capacity => CAPACITY;
        public List<IAnimal> Animals { get; }
        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count == CAPACITY)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (Animals.Any(x => x.Name == animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            Animals.Add(animal);
        }

        public void Adopt(string animalName, string owner)
        {
            IAnimal animalToAdopt = Animals.FirstOrDefault(x => x.Name == animalName);
            if (animalToAdopt == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animalToAdopt.Owner = owner;
            animalToAdopt.IsAdopt = true;
            Animals.Remove(animalToAdopt);
        }
    }
}
