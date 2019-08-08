using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IAnimal animal = new Cat("Pena",12,20,23);
            IProcedure procedure = new Chip();
            procedure.DoService(animal,12);
        }
    }
}
