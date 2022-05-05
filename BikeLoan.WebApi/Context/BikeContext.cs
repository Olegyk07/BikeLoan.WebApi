namespace BikeLoan.WebApi.Context
{
    using Microsoft.EntityFrameworkCore;
    using BikeLoan.WebApi.Models;
    public class BikeContext : DbContext
    {
        public BikeContext(DbContextOptions<BikeContext> options)
            : base(options)
        {
            
        }
        public DbSet<Bike> Bikes { get; set; }
    }
}
