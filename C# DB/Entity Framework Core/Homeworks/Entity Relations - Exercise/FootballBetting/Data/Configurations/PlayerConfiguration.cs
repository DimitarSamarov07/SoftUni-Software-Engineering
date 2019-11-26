namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PlayerConfiguration:IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasOne(p => p.Team)
                .WithMany(o => o.Players)
                .HasForeignKey(fk => fk.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Position)
                .WithMany(o => o.Players)
                .HasForeignKey(fk => fk.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
