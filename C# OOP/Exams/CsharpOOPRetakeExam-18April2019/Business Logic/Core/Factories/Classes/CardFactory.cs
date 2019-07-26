using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Classes;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories.Classes
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
