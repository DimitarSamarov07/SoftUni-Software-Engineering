namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PlayerStatisticConfiguration:IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder
                .HasKey(k => new {k.GameId, k.PlayerId});

            builder
                .HasOne(p => p.Game)
                .WithMany(o => o.PlayerStatistics)
                .HasForeignKey(fk => fk.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Player)
                .WithMany(o => o.PlayerStatistics)
                .HasForeignKey(fk => fk.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
