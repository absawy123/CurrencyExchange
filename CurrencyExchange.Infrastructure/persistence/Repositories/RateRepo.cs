using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Infrastructure.persistence.Repositories
{
    public class RateRepo : GenericRepo<RateRepo>, IExchangeRateRepo
    {
        private readonly AppDbContext _context;
        public RateRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }



    }
}
