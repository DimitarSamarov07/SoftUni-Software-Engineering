using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories.Classes
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public IReadOnlyCollection<ICard> Cards => cards;
        public int Count => Cards.Count;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if (Cards.Any(p => p.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return cards.Remove(card);
        }

        public ICard Find(string name)
        {
            ICard card = cards.FirstOrDefault(p => p.Name == name);
            return card;
        }
    }
}
