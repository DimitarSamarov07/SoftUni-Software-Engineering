using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Birthday_Celebrations
{
    public class Control : ICitizen, IRobot,IPet
    {
        private DateTime birthDate;

        public Control(string name, int age, string id,DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
        public Control(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public Control(string name,DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string Model { get; set; }

    }
}
