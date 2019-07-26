using System;
using System.Text;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories.Classes;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Classes;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Classes;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    public class ManagerController : IManagerController
    {
        public ManagerController()
        {
            PlayerRepository = new PlayerRepository();
            CardRepository = new CardRepository();
        }

        public IPlayerRepository PlayerRepository { get; set; }
        public ICardRepository CardRepository { get; set; }
        public string AddPlayer(string type, string username)
        {
            IPlayerFactory fact = new PlayerFactory();
            IPlayer toAdd = fact.CreatePlayer(type, username);
            PlayerRepository.Add(toAdd);
            return String.Format("Successfully added player of type {0} with username: {1}", toAdd.GetType().Name, toAdd.Username);
        }

        public string AddCard(string type, string name)
        {
            ICardFactory fact = new CardFactory();
            ICard toAdd = fact.CreateCard(type, name);
            CardRepository.Add(toAdd);
            return $"Successfully added card of type {toAdd.GetType().Name} with name: {toAdd.Name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer user = PlayerRepository.Find(username);
            ICard card = CardRepository.Find(cardName);
            user.CardRepository.Add(card);
            return $"Successfully added card: {card.Name} to user: {user.Username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            BattleField field = new BattleField();
            IPlayer attacker = PlayerRepository.Find(attackUser);
            IPlayer enemy = PlayerRepository.Find(enemyUser);
            field.Fight(attacker,enemy);
            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in PlayerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
