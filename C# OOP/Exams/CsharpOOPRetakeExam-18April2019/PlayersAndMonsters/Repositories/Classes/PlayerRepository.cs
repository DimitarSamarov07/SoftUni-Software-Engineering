using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories.Classes
{
    public class PlayerRepository:IPlayerRepository
    {
        private List<IPlayer> players;
        public int Count { get; set; }

        public PlayerRepository()
        {
            Players=new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Players
        {
            get => players;
            private set => players = value.ToList();
        }

        public void Add(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else if (Players.Contains(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            else
            {
                players.Add(player);
            }
        }

        public bool Remove(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else
            {
                if (players.Contains(player))
                {
                    players.Remove(player);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IPlayer Find(string username)
        {
            List<IPlayer> player = this.players.Where(p => p.Username == username).ToList();
            return player[0];
        }
    }
}
