using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class CommandoFactory
    {
        public Commando CreateCommando(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Commando commando = new Commando(id, firstName, lastName, salary, corps);

            return commando;
        }
    }
}
