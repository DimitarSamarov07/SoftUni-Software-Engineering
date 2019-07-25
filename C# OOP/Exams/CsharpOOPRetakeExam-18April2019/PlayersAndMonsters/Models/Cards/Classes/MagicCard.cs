using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Classes
{
    public class MagicCard:Card
    {
        public MagicCard(string name) 
            : base(name, 5,80)
        {
        }
    }
}
