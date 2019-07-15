using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    class Astronaut
    {
        private string name;
        private int age;
        private string country;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public Astronaut(string name,int age,string country)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Astronaut: {name}, {age} ({country})");
            return sb.ToString().TrimEnd();
        }
    }
}
