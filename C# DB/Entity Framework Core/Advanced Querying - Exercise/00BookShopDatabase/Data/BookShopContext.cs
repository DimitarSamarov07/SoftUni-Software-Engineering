namespace BookShop.Data
{
    using System.Reflection;
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BookShopContext:DbContext
    {

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
