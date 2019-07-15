using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OrderByAge
{
    public class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> personsDetails = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] details = line.Split();

                string name = details[0];
                string iD = details[1];
                int age = int.Parse(details[2]);

                Person person = new Person(name, iD, age);
                personsDetails.Add(person);
            }

            List<Person> finalList = personsDetails.OrderBy(x => x.Age).ToList();

            foreach (var person in finalList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}