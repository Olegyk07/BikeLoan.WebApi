namespace BikeLoan.WebApi.Models
{
    using BikeLoan.WebApi.Context;
    using System.Linq;

    public static class InitialData
    {
        public static void Seed(this BikeContext dbContext)
        {
            if (!dbContext.Bikes.Any())
            {
                dbContext.Bikes.Add(new Bike
                {
                    BikeName = "BMX",
                    BikeColor = "Red",
                    BikePrice = 1200
                });
                dbContext.Bikes.Add(new Bike
                {
                    BikeName = "Ukraina",
                    BikeColor = "Black",
                    BikePrice = 2000
                });
                dbContext.Bikes.Add(new Bike
                {
                    BikeName = "Veturillo",
                    BikeColor = "White",
                    BikePrice = 3700
                });

                dbContext.SaveChanges();
            }
        }
    }
}
