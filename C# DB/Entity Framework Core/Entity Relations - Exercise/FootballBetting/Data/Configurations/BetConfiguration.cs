namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BetConfiguration:IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(o => o.Bets)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Game)
                .WithMany(p => p.Bets)
                .HasForeignKey(fk => fk.BetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
