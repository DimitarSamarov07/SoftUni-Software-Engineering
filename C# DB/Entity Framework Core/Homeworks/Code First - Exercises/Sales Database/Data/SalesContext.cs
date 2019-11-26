namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Products
            modelBuilder
                .Entity<Product>()
                .HasKey(k => k.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(fk => fk.ProductId);

            //Sales
            modelBuilder
                .Entity<Sale>()
                .HasKey(k => k.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(fk => fk.ProductId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Store)
                .WithMany(p => p.Sales)
                .HasForeignKey(fk => fk.StoreId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Customer)
                .WithMany(p => p.Sales)
                .HasForeignKey(fk => fk.CustomerId);

            //Customers
            modelBuilder
                .Entity<Customer>()
                .HasKey(k => k.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Email)
                .IsUnicode(false);

            modelBuilder
                .Entity<Customer>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Customer)
                .HasForeignKey(fk => fk.CustomerId);


            //Stores
            modelBuilder
                .Entity<Store>()
                .HasKey(k => k.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Store)
                .HasForeignKey(fk => fk.StoreId);
        }
    }
}
