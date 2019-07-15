using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    class SpaceStation
    {
        private string name;
        private int capacity;
        private List<Astronaut> data;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count => data.Count;
        

        public SpaceStation(string name,int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            data= new List<Astronaut>();
        }
        public void Add(Astronaut astronaut)
        {
            if (data.Count<capacity)
            {
                data.Add(astronaut);
            }

           
        }

        public bool Remove(string nameParam)
        {
            Astronaut[] forRemove = data.Where(x => x.Name == nameParam).ToArray();
            if (forRemove.Length>0)
            {
                if (data.Contains(forRemove[0]))
                {
                    data.Remove(forRemove[0]);
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            int sum = 0;
            Astronaut oldestOne = new Astronaut("JOHN_CENA!!",12,"JOHN_CENA!!!");

            foreach (var astronaut in data)
            {
                if (astronaut.Age>sum)
                {
                    sum = astronaut.Age;
                    oldestOne = astronaut;
                }
            }

            return oldestOne;
        }

        public Astronaut GetAstronaut(string nameParam)
        {
            Astronaut fake = new Astronaut("hghuijj",222222,"NHJUDHD");
            foreach (var astronaut in data)
            {
                if (astronaut.Name== nameParam)
                {
                    return astronaut;
                }

                else
                {
                    return fake;
                }
            }

            return fake;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Astronauts working at Space Station {spaceStationName}:" + Environment.NewLine);
            foreach (var item in data)
            {
                sb.Append(item);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString().TrimEnd();


        }
    }
}
