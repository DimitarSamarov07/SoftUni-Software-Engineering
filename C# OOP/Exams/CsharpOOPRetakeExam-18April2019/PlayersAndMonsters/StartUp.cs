using PlayersAndMonsters.Models.BattleFields.Classes;
using PlayersAndMonsters.Models.Cards.Classes;
using PlayersAndMonsters.Models.Players.Classes;
using PlayersAndMonsters.Repositories.Classes;

namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Card BOOOM = new MagicCard("BOOM");
            ICardRepository repo = new CardRepository();
            repo.Add(BOOOM);
            Player ivan = new Beginner(repo, "IVAN");
            Player pesho = new Advanced(repo, "PESHO");
            BattleField battleField = new BattleField();
            battleField.Fight(ivan,pesho);
            
        }
    }
}