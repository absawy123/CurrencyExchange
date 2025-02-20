using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Infrastructure.persistence.Repositories
{
    public class CountryRepo : GenericRepo<Country> , ICountryRepo
    {
        private readonly AppDbContext _context;

        public CountryRepo(AppDbContext context):base(context)
        {
            _context = context;
        }





    }
}
