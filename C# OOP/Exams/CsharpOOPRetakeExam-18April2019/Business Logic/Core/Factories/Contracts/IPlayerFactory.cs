

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username);
    }
}
