using System.Collections.Generic;
using System.Reflection.Metadata;
using AnimalCentre.Models.Animals;

namespace AnimalCentre.Models.Contracts
{
    public interface IHotel
    { 
        IReadOnlyDictionary<string,IAnimal> Animals { get;}
       void Accommodate(IAnimal animal);
       void Adopt(string animalName, string owner);
    }
}
