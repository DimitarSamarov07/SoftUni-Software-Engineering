﻿using PlayersAndMonsters.Models.Players.Contracts;

namespace Structure.Core.Factories.Contracts
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username);
    }
}
