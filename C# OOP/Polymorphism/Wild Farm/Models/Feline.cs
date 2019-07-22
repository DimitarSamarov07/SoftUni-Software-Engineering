using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Core
{
    public abstract class Feline:Mammal
    {
        public Feline(string name, double weight,string livingRegion,string breed) 
            : base(name, weight,livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string type = GetType().Name.ToString();
            return $"{type} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]".TrimEnd();
        }
    }
}
