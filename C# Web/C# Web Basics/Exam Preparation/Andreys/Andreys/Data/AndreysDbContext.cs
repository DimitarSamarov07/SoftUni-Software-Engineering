namespace Andreys.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class AndreysDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.\\SQLEXPRESS;Database=AndreysDB;Integrated Security=true");
            }
        }
    }
}
