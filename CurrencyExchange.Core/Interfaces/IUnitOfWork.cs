using CurrencyExchange.Core.Entities;

namespace CurrencyExchange.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepo<Currency> CurrencyRepo { get; }
        public IGenericRepo<ExchangeRate> RateRepo { get; }
        public IGenericRepo<Country> CountryRepo { get; }
        Task<int> SaveChangesAsync();


    }
}
