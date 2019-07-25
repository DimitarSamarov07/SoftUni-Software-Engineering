using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;

namespace PlayersAndMonsters.Models.BattleFields.Classes
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            } 
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            enemyPlayer.Health += enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            while (true)
            {
                int attackerDamagePoints = attackPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }
    }
}
