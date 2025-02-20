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

    }

}

