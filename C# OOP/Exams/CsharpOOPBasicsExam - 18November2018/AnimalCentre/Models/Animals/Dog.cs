namespace AnimalCentre.Models.Animals
{
    public class Dog:Animal
    {
        public Dog(string name, int energy, int happiness, int produceTime) 
            : base(name, energy, happiness, produceTime)
        {
        }
    }
}
