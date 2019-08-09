using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core.Factories
{
    public class AnimalFactory
    {
        public IAnimal MakeAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (type == "Cat")
            {
                return new Cat(name, energy, happiness, procedureTime);
            }
            if (type == "Dog")
            {
                return new Dog(name, energy, happiness, procedureTime);
            }
            if (type == "Lion")
            {
                return new Lion(name, energy, happiness, procedureTime);
            }
            if (type == "Pig")
            {
                return new Pig(name, energy, happiness, procedureTime);
            }
            return new Cat("PENA",2,100,22);
        }
    }
}
