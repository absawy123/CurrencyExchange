using CurrencyExchange.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int> , int>
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

      
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

    }

}

