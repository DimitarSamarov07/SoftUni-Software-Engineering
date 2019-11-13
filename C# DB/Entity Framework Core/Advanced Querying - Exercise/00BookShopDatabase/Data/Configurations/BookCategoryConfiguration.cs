namespace BookShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BookCategoryConfiguration:IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder
                .HasKey(k => new {k.BookId, k.CategoryId});

            builder
                .HasOne(p => p.Book)
                .WithMany(o => o.BookCategories)
                .HasForeignKey(fk => fk.BookId);

            builder
                .HasOne(p => p.Category)
                .WithMany(o => o.CategoryBooks)
                .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
