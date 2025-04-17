using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Application.Services
{
    public class CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(Currency currency)
        {
            await _unitOfWork.CurrencyRepo.AddAsync(currency);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Currency> GetByIdAsync(int id) => await _unitOfWork.CurrencyRepo.GetAsync(c => c.Id == id);

        public async Task<Currency> GetById(int id) => await _unitOfWork.CurrencyRepo.GetAsync(c => c.Id == id);

        public async Task<IEnumerable<Currency>> GetAllAsync(bool isTracked = true)
            => await _unitOfWork.CurrencyRepo.GetAllAsync(isTracked :isTracked);

        public async Task Update(Currency currency)
        {
            _unitOfWork.CurrencyRepo.Update(currency);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Remove(Currency currency)
        {
            _unitOfWork.CurrencyRepo.Remove(currency);
            await _unitOfWork.SaveChangesAsync();        
        }
        public async Task<IEnumerable<Currency>> GetAllByCode(string code) => 
            await _unitOfWork.CurrencyRepo
            .GetAllAsync(c => c.Code==code);

        public async Task<IEnumerable<Currency>> GetAllPaginated(int pageSize, int pageNumber) =>
            await _unitOfWork.CurrencyRepo
            .GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);


    }
}
