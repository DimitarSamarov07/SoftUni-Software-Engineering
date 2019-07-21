using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Wild_Farm.Core;
using Wild_Farm.Core.Animals.Birds;
using Wild_Farm.Core.Animals.Mammals;
using Wild_Farm.Core.Animals.Mammals.Felines;
using Wild_Farm.Core.Food;

namespace Wild_Farm
{
    public class StartUp
    {
        public static List<Animal> animals;
        public static void Main(string[] args)
        {
            string command;
            animals=new List<Animal>();

            while ((command=Console.ReadLine())!="End")
            {
                string[] animal = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] food = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfAnimal = animal[0];
                string typeOfFood = food[0];
                int foodQuantity = int.Parse(food[1]);
                Animal currentAnimal = GetAnimal(typeOfAnimal,animal);
                Food currentFood = GetFood(typeOfFood, foodQuantity);
                currentAnimal.Feed(currentFood,typeOfFood);
                animals.Add(currentAnimal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().DeclaringType.ToString()+" "+animal);
                Console.WriteLine(Environment.NewLine);
            }
        }

        public static Animal GetAnimal(string type,string[] animal)
        {
            string name = animal[1];
            double weight = double.Parse(animal[2]);
            string livingRegion;
            double wingSize;
            string breed;
            if (type=="Owl")
            {
                weight = double.Parse(animal[2]);
                wingSize = double.Parse(animal[3]);
                return new Owl(name,weight,wingSize);
            }

            else if(type=="Hen")
            {
                weight = double.Parse(animal[2]);
                wingSize = double.Parse(animal[3]);
                return new Hen(name,weight,wingSize);
            }

            else if (type=="Mouse")
            {
                livingRegion = animal[3];
                return new Mouse(name,weight,livingRegion);
            }

            else if (type=="Dog")
            {
                livingRegion = animal[3];
                return new Dog(name,weight,livingRegion);
            }

            else if (type=="Cat")
            {
                livingRegion = animal[3];
                breed = animal[4];
                return new Cat(name,weight,livingRegion,breed);
            }

            else if (type=="Tiger")
            {
                livingRegion = animal[3];
                breed = animal[4];
                return new Tiger(name,weight,livingRegion,breed);
            }

            else
            {
                return new Cat("PESHO THE GOD",32,"BULGARIAAAAA","MOZAAAAK");
            }
        }

        public static Food GetFood(string type,int quantity)
        {
            if (type=="Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type=="Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type=="Meat")
            {
                return new Meat(quantity);
            }
            else if (type=="Seeds")
            {
                return new Seeds(quantity);
            }
            else
            {
                return new Seeds(quantity+6464664);
            }
        }
    }
}
