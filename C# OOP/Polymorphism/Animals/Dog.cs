using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog:Animal
    {
        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"I am {Name} and my fovourite food is {FavouriteFood}"+Environment.NewLine);
            sb.Append("DJAAF");
            return sb.ToString().TrimEnd();
        }
    }
}
