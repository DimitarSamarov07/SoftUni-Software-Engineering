using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string favouriteFood;
        private string name;

        public Animal(string name,string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string FavouriteFood
        {
            get => favouriteFood;
            set => favouriteFood = value;
        }

        public virtual string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"I am {Name} and my fovourite food is {FavouriteFood}"+Environment.NewLine);
            sb.Append("ANIMALLLLLS");
            return sb.ToString().TrimEnd();
        }
    }
}
