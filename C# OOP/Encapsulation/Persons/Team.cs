using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam=new List<Person>();
            reserveTeam=new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get => firstTeam;
            private set => firstTeam = value.ToList();
        }
        public IReadOnlyList<Person> ReserveTeam
        {
            get => reserveTeam;
            private set => reserveTeam = value.ToList();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age<40)
            {
                firstTeam.Add(person);
            }

            else
            {
                reserveTeam.Add(person);
            }
        }

    }
}
