using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Classes;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields.Classes
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            while (true)
            {
                if (attackPlayer.IsDead||enemyPlayer.IsDead)
                {
                    throw new ArgumentException("Player is dead!");
                } 
                if (attackPlayer.GetType().Name == "Beginner" || enemyPlayer.GetType().Name == "Beginner")
                {
                    if (attackPlayer.GetType().Name == "Beginner")
                    {
                        attackPlayer.Health += 40;
                        foreach (var card in attackPlayer.CardRepository.Cards)
                        {
                            card.DamagePoints += 30;
                        }
                    }

                    else
                    {
                        enemyPlayer.Health += 40;
                        foreach (var card in enemyPlayer.CardRepository.Cards)
                        {
                            card.DamagePoints += 30;
                        }
                    }
                }

                foreach (var item in attackPlayer.CardRepository.Cards)
                {
                    attackPlayer.Health += item.HealthPoints;
                }
                foreach (var item in enemyPlayer.CardRepository.Cards)
                {
                    enemyPlayer.Health += item.HealthPoints;
                }

                int attackerDamage = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                int enemyDamage = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamage);
                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamage);
                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
            
        }
    }
}
