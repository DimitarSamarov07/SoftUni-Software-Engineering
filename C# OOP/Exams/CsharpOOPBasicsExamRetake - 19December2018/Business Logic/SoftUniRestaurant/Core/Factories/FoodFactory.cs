using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Core.Factories
{
    public class FoodFactory
    {
        public IFood MakeFood(string type, string name, decimal price)
        {
            if (type=="Dessert")
            {
                return new Dessert(name,price);
            }
            if (type=="MainCourse")
            {
                return new MainCourse(name,price);
            }
            if (type=="Salad")
            {
                return new Salad(name,price);
            }
            if (type=="Soup")
            {
                return new Soup(name,price);
            }

            return null;
        }
    }
}
