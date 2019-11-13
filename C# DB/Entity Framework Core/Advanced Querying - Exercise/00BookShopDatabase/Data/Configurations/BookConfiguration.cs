namespace BookShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasOne(p => p.Author)
                .WithMany(o => o.Books)
                .HasForeignKey(fk => fk.AuthorId);
        }
    }
}
