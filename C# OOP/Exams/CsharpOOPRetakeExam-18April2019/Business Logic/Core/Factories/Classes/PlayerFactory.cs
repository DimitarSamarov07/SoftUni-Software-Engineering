
using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters
{
    public class PlayerFactory:IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            if (type=="Beginner")
            {
                return new Beginner(new CardRepository(), username);
            }

            if (type=="Advanced")
            {
                return new Advanced(new CardRepository(),username);
            }
            return new Advanced(new CardRepository(), "PESHOOOO");
        }
    }
}
