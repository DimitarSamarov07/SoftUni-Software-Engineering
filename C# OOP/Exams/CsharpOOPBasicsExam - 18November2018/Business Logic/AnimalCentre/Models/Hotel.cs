using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }
        private const int Capacity = 10;
        public IReadOnlyDictionary<string, IAnimal> Animals => animals;
        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name,animal);
        }

        public void Adopt(string animalName, string owner)
        {
            IAnimal animalToAdopt = Animals.Values.FirstOrDefault(x=>x.Name==animalName);
            if (animalToAdopt == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animalToAdopt.Owner = owner;
            animalToAdopt.IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
