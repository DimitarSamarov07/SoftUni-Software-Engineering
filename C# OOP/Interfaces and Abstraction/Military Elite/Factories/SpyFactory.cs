using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class SpyFactory
    {
        public Spy CreateSpy(string id, string firstName, string lastName, int codeNumber)
        {
            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }
    }
}
