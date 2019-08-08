using System.Collections.Generic;
using System.Reflection.Metadata;
using AnimalCentre.Models.Animals;

namespace AnimalCentre.Models.Contracts
{
    public interface IHotel
    {
       int Capacity { get;}
       List<IAnimal> Animals { get;}
       void Accommodate(IAnimal animal);
       void Adopt(string animalName, string owner);
    }
}
