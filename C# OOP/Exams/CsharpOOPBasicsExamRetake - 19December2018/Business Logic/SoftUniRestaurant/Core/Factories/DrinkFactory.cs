using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Core.Factories
{
    public class DrinkFactory
    {
        public IDrink MakeDrink(string type,string name,int servingSize,string brand)
        {
            if (type=="Water")
            {
                return new Water(name,servingSize,brand);
            }
            if (type=="Alcohol")
            {
                return new Alcohol(name,servingSize,brand);
            }
            if (type=="Juice")
            {
                return new Juice(name,servingSize,brand);
            }
            if (type=="FuzzyDrink")
            {
                return new FuzzyDrink(name,servingSize,brand);
            }

            return null;
        }
    }
}
