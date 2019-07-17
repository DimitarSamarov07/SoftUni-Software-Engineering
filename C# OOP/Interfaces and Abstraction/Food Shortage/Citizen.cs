using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Citizen:IBuyer
    {
        public Citizen(string name,int age,string id,DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; }
        public int Food { get; set; }
        public DateTime BirthDate { get; set; }
        public void BuyFood()
        {
            Food += 10;
        }

        public int GetFoodAmount()
        {
            return this.Food;
        }
    }
}
