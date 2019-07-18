using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class EngineerFactory
    {
        public Engineer CreateEngineer(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            return engineer;
        }
    }
}
