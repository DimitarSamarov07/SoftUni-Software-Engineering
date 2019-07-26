

using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username);
    }
}
