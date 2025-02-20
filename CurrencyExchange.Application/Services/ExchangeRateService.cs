using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Application.Services
{
    public class ExchangeRateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeRateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(ExchangeRate rate) => await _unitOfWork.RateRepo.AddAsync(rate);

        public async Task<IEnumerable<ExchangeRate>> GetAllAsync() => await _unitOfWork.RateRepo.GetAllAsync();

        public void Update(ExchangeRate rate) => _unitOfWork.RateRepo.Update(rate);

        public void Remove(ExchangeRate rate) => _unitOfWork.RateRepo.Remove(rate);
    }
}
