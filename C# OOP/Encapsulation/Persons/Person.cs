using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                else
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length<3)
                {
                   throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                else
                {
                    lastName = value;
                }
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                else
                {
                    age = value;
                }
            }
        }

        public decimal Salary
        {
            get => salary;
            private set
            {
                if (value<460)
                {
                   throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                else
                {
                    salary = value;
                }
               
            }
        }

        public Person(string firstName,string lastName,int age,decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age >= 30)
            {
                Salary += Salary*percentage / 100;
            }

            else
            {
                Salary +=Salary* percentage / 200;
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

    }
}
