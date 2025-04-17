using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace CurrencyExchange.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {

        private readonly ExchangeRateService _exchangeRateService;
        public ExchangeRateController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;

        }

        [HttpGet("GetRatesAt")]
        public async Task<ActionResult<IEnumerable<ExchangeRateDto>>> GetRatesAt(DateTime date)
        {
           var rates = await _exchangeRateService.GetRatesAt(date);
           if (rates == null)
            {
                return NotFound("There are no rates at this date");
            }

           var ratesDtos =new List<ExchangeRateDto>();
            foreach (var item in rates)
            {
                var rateDto = new ExchangeRateDto()
                {
                    CurrencyName =item.Currency.Name,
                    Rate = item.Rate,
                    Date =item.RateDate
                };
            }
            return Ok(ratesDtos);


        }




    }
}
