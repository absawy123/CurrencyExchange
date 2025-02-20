using CurrencyExchange.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.persistence
{
    public class AppDbContext : DbContext
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Find USD currency ID (assuming it exists)
            var usdCurrencyId = 1; // Change if needed (get actual ID in a real case)

            var random = new Random();
            var exchangeRates = new List<ExchangeRate>();

            for (int i = 2; i <= 200; i++) // Assuming ID 1 is USD
            {
                exchangeRates.Add(new ExchangeRate
                {
                    Id = i, // Ensure unique IDs
                    CurrencyId = i,
                    Rate = (decimal)(random.NextDouble() * (5 - 0.1) + 0.1), // Random rates from 0.1 to 5
                    RateDate = DateOnly.FromDateTime(DateTime.UtcNow)
                });
            }

            modelBuilder.Entity<ExchangeRate>().HasData(exchangeRates);
        }
    }

}

