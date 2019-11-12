namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TownConfiguration:IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder
                .HasOne(p => p.Country)
                .WithMany(o => o.Towns)
                .HasForeignKey(fk => fk.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
