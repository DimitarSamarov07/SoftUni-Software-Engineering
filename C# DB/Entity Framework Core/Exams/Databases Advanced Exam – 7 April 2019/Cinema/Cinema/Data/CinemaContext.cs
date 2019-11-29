namespace Cinema.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CinemaContext : DbContext
    {
        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Projections
            modelBuilder
                .Entity<Projection>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Projections)
                .HasForeignKey(fk => fk.MovieId);

            modelBuilder
                .Entity<Projection>()
                .HasOne(x => x.Hall)
                .WithMany(x => x.Projections)
                .HasForeignKey(fk => fk.HallId);

            //Tickets
            modelBuilder
                .Entity<Ticket>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Tickets)
                .HasForeignKey(fk => fk.CustomerId);

            modelBuilder
                .Entity<Ticket>()
                .HasOne(x => x.Projection)
                .WithMany(x => x.Tickets)
                .HasForeignKey(fk => fk.ProjectionId);

            //SeatsCount
            modelBuilder
                .Entity<Seat>()
                .HasOne(x => x.Hall)
                .WithMany(x => x.Seats)
                .HasForeignKey(fk => fk.HallId);

        }
    }
}