﻿using System.Collections.Generic;

namespace PlayersAndMonsters
{
    public interface ICardRepository
    {
        int Count { get; }
        
        IReadOnlyCollection<ICard> Cards { get;}

        void Add(ICard card);

        bool Remove(ICard card);

        ICard Find(string name);
    }
}
