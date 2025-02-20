using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.persistence.Repositories
{
    public class CurrencyRepo : GenericRepo<Currency>,ICurrencyRepo 
    {
        private readonly AppDbContext _context;
        public CurrencyRepo(AppDbContext context):base(context)
        {
            _context = context;
        }




    }
}
