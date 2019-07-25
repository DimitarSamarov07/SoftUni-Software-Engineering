namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public interface ICard
    {
        string Name { get; set; }

        int DamagePoints { get; set; }

        int HealthPoints { get; set; }
    }
}
