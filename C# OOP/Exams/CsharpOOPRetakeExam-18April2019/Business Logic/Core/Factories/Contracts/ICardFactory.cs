﻿

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public interface ICardFactory
    {
        ICard CreateCard(string type, string name);
    }
}
