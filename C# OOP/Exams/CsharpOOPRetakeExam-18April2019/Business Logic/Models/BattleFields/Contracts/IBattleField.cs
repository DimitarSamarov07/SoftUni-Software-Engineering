namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    public interface IBattleField
    {
        void Fight(IPlayer attackPlayer, IPlayer enemyPlayer);
    }
}
