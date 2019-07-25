using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters
{
    public class CardFactory:ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type=="Magic")
            {
                return new MagicCard(name);
            }

            if (type=="Trap")
            {
                return new TrapCard(name);
            }
            return new MagicCard(name);
        }
    }
}
