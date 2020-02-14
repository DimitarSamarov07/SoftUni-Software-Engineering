namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SULSContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.\\SQLEXPRESS;Database=SULS;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}