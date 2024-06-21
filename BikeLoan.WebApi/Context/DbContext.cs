namespace BikeLoan.WebApi.Context
{
    using Microsoft.EntityFrameworkCore;
    using BikeLoan.WebApi.Models;
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>()
                .HasOne<Users>(s => s.Users)
                .WithMany(g => g.Bikes)
                .HasForeignKey("UserId");

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Orders)
                .WithOne(b => b.Customer)
                .HasForeignKey("CustomerId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bike>()
                .HasMany(b => b.Orders)
                .WithOne(o => o.Bike)
                .HasForeignKey("BikeId");
        }
    }

}
