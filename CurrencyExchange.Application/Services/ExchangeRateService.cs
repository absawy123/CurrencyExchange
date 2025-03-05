using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using System.Collections;

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
        public async Task<IEnumerable<ExchangeRate>> GetRatesAt(DateTime date) =>
            await _unitOfWork.RateRepo.
            GetAllAsync(filter: (r => r.RateDate.Year == date.Year), includes: ex => ex.Currency);
        public void Update(ExchangeRate rate) => _unitOfWork.RateRepo.Update(rate);
        public void Remove(ExchangeRate rate) => _unitOfWork.RateRepo.Remove(rate);

    }
}
