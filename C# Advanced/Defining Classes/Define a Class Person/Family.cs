using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> peoples =new List<Person>();

        public List<Person> Peoples
        {
            get { return peoples; }
            set { peoples = value; }
        }

        public void AddMember(Person member)
        {
            peoples.Add(member);
        }

        public Person GetOldestMember()
        {
            foreach (var person in peoples.OrderByDescending(x => x.Age))
            {
                Person per = new Person(person.Name,person.Age);
                return per;
            }

            return new Person();
            
        }

        public Dictionary<string,int> GetUnder30()
        {
            Dictionary<string,int> guys = new Dictionary<string, int>();
            foreach (var item in peoples)
            {
                if (item.Age>30)
                {
                    guys.Add(item.Name,item.Age);
                }
            }

            return guys;
        }

    }
}
