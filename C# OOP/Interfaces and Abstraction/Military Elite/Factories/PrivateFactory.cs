using _08MilitaryElite.Interfaces;
using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class PrivateFactory : SoldierFactory, ISoldier
    {
        public PrivateFactory(string id, string firstName, string lastName, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        //public Private CreatePrivate(string id, string firstName, string lastName, decimal salary)
        //{
        //    Private soldier = new Private(id, firstName, lastName, salary);

        //    return soldier;
        //}

        public override Soldier GetSoldier()
        {
            return new Private(this.Id, this.FirstName, this.LastName, this.Salary);
        }
    }
}
