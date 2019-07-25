using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories.Classes
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        public int Count => Cards.Count;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public IReadOnlyCollection<ICard> Cards => cards;
        

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            else if (Cards.Any(p => p.Name == card.Name))
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

            else
            {
                if (cards.Contains(card))
                {
                    cards.Remove(card);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ICard Find(string name)
        {
            ICard card = cards.FirstOrDefault(p => p.Name == name);
            return card;
        }
    }
}
