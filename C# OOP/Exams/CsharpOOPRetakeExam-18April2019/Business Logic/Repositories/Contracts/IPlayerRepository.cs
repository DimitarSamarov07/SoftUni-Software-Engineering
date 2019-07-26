using System.Collections.Generic;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public interface IPlayerRepository
    {
        int Count { get;}

        IReadOnlyCollection<IPlayer> Players { get; }

        void Add(IPlayer player);

        bool Remove(IPlayer player);

        IPlayer Find(string username);
    }
}
