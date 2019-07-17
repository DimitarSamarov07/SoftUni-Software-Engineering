using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Border_Control
{
    public class Control:ICitizen,IRobot
    {
        public Control(string name,int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public Control(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Model { get; set; }

    }
}
