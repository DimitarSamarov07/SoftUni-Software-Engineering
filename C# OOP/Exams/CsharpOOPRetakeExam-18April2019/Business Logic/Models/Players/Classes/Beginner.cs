namespace PlayersAndMonsters
{
    public class Beginner : Player

    {
        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username,50)
        {

        }

        
    }
}
