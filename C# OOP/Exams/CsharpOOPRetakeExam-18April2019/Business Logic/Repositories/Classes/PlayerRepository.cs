using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories.Classes
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;
        public int Count => players.Count;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Players => players;



        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (Players.Any(p=>p.Username==player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return players.Remove(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = players.FirstOrDefault(p => p.Username == username);
            return player;
        }
    }
}
