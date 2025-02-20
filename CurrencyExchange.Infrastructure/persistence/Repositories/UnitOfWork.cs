using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Infrastructure.persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context,
            IGenericRepo<Country> countryRepo,
            IGenericRepo<Currency> currencyRepo,
            IGenericRepo<ExchangeRate> rateRepo)
        {
            _context = context;
            CountryRepo = countryRepo;
            CurrencyRepo = currencyRepo;
            RateRepo = rateRepo;
        }

        public IGenericRepo<Currency> CurrencyRepo { get; private set; } = null!;

        public IGenericRepo<ExchangeRate> RateRepo { get; private set; } = null!;

        public IGenericRepo<Country> CountryRepo { get; private set; } = null!;

        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
       
    }
}
