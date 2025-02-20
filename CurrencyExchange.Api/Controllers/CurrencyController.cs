using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Application.Dtos.country;
using CurrencyExchange.Application.Services;
using CurrencyExchange.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;

        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody]CurrencyDto currencyDto)
        {
            if (ModelState.IsValid)
            {
                var currency = new Currency()
                {
                    Name = currencyDto.Name,
                    Code = currencyDto.Code
                };
                await _currencyService.AddAsync(currency);
                return Created();
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        [ResponseCache(Duration =60)]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetAllAsync()
        {
            var currencies = await _currencyService.GetAllAsync(isTracked: false);
            var currencyDtos = currencies.Select(c => new CountryDto
            {
                Name = c.Name,
                Code = c.Code
            }).ToList();

            return Ok(currencyDtos);
        }

        [HttpGet("GetAllByCode/{code:alpha}")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllByCodeAsync(string code)
        {
            if(code == null)
                return BadRequest();
            var currencies = await _currencyService.GetAllByCode(code);
            return Ok(currencies);
        }

        [HttpGet("GetAllPaginated/{pageSize:int}/{pageNumber:int}")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllPaginated(int pageSize , int pageNumber)
        {
            if (pageSize > 0 && pageNumber > 0)
            {
                var currencies = await _currencyService.GetAllPaginated(pageSize: pageSize, pageNumber: pageNumber);
                return Ok(currencies);
            }
            return BadRequest();
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CurrencyDto currencyDto)
        {
            var country = await _currencyService.GetByIdAsync(id);
            if (country == null)
                return NotFound("currencyId is not found");
            else
            {
                country.Code = currencyDto.Code;
                country.Name = currencyDto.Name;
                _currencyService.Update(country);
                return NoContent();
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var currency =await _currencyService.GetById(id);
            if (currency != null)
            {
                _currencyService.Remove(currency);
                return NoContent();
            }
            return BadRequest();
        }

    }
}
