
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Classes;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Classes;

namespace PlayersAndMonsters.Core.Factories.Classes
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
