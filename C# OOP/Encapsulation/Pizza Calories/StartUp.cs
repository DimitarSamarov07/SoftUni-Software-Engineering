using System;
using System.Data;
using System.Linq;

namespace Pizza_Calories
{
    public class StartUp
    {
        public static Pizza Pizza;
        static void Main(string[] args)
        {

            string line;
            while ((line =Console.ReadLine())!="END")
            {
                string[] input = line
                    .Split(" ")
                    .ToArray();
                string command = input[0];

                if (command=="Pizza")
                {
                    string name = input[1];
                    Pizza= new Pizza(name);
                }

                else if (command=="Topping")
                {
                    string type = input[1];
                    double grams = double.Parse(input[2]);
                    Topping toAdd = new Topping(type,grams);
                    Pizza.AddTopping(toAdd);
                }

                else if (command=="Dough")
                {
                    string flour = input[1];
                    string technique = input[2];
                    double grams = double.Parse(input[3]);
                    Dough toAdd = new Dough(flour,technique,grams);
                    Pizza.SetDough(toAdd);
                }
            }

            Console.WriteLine($"{Pizza.Name} - {Pizza.GetTotalCalories():f2} Calories.");

           
            
        }
    }
}
