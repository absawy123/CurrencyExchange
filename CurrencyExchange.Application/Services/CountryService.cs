using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using System.Linq.Expressions;

namespace CurrencyExchange.Application.Services
{
    public class CountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(Country country)
        {
            await _unitOfWork.CountryRepo.AddAsync(country);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task<Country> GetByIdAsync(int id) => await _unitOfWork.CountryRepo.GetAsync(c => c.Id == id);
        public async Task<IEnumerable<Country>> GetAllAsync(Expression<Func<Country,bool>> filter =null!,
            bool isTracked = true ,int pageSize =0 ,int pageNumber =0,params Expression<Func<Country,object>>[] includes) =>
            await _unitOfWork.CountryRepo.GetAllAsync(isTracked:isTracked ,pageSize:pageSize ,includes:includes);
      
        public async Task Update(Country country)
        {
            _unitOfWork.CountryRepo.Update(country); 
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Remove(Country country)
        {
            _unitOfWork.CountryRepo.Remove(country);
            await _unitOfWork.SaveChangesAsync();        
        }
    }
}
