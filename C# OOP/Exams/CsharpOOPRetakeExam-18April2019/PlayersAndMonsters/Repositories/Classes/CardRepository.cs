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
        public int Count { get; }

        public CardRepository()
        {
            Cards = new List<ICard>();
        }
        public IReadOnlyCollection<ICard> Cards
        {
            get => cards;
            private set { cards = value.ToList(); }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            else if (Cards.Contains(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            else
            {
                cards.Add(card);
            }
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
            List<ICard> card = cards.Where(c => c.Name == name).ToList();
            return card[0];
        }
    }
}
