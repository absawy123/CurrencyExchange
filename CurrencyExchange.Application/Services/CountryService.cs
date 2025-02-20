using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Application.Services
{
    public class CountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(Country country) => await _unitOfWork.CountryRepo.AddAsync(country);
        public async Task<Country> GetById(int id) => await _unitOfWork.CountryRepo.GetAsync(c => c.Id == id);

        public async Task<IEnumerable<Country>> GetAllAsync(bool isTracked = true) =>
            await _unitOfWork.CountryRepo.GetAllAsync(isTracked :isTracked);
        public async Task<Country> GetByIdAsync(int id) => await _unitOfWork.CountryRepo.GetAsync(c => c.Id == id);

        public void Update(Country country) =>  _unitOfWork.CountryRepo.Update(country);

        public void Remove(Country country) => _unitOfWork.CountryRepo.Remove(country);

    }
}
