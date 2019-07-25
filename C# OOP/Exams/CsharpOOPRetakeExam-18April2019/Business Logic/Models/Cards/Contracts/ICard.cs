namespace PlayersAndMonsters
{
    public interface ICard
    {
        string Name { get; }

        int DamagePoints { get; set; }

        int HealthPoints { get;}
    }
}
