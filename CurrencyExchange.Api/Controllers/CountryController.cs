using CurrencyExchange.Application.Dtos.country;
using CurrencyExchange.Application.Services;
using CurrencyExchange.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CountryExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService CountryService)
        {
            _countryService = CountryService;

        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                var country = new Country()
                {
                    Name = countryDto.Name,
                    Code = countryDto.Code,
                    CurrencyId = countryDto.CurrencyId,
                };
                await _countryService.AddAsync(country);
                return Created();
            }
            return BadRequest();
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CountryDto>> GetByIdAsync(int id)
        {
            var country = await _countryService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound("There is no country");
            }
            var countryDto = new CountryDto()
            {
                Name = country.Name,
                Code = country.Code,
                CurrencyId = country.CurrencyId,
            };
            return Ok(countryDto);
        }

        [ResponseCache(Duration = 60)]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CountryDto>>> GetAllAsync()
        {
            var countries = await _countryService.GetAllAsync(isTracked:false);
            var countryDtos = countries.Select(c => new CountryDto
            {
                Name = c.Name,
                Code = c.Code,
                CurrencyId = c.CurrencyId
            }).ToList();

            return Ok(countryDtos);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CountryDto countryDto)
        {
            var country = await _countryService.GetByIdAsync(id);
            if (country == null)
                return NotFound("Country Id is not found");
            else
            {
                country.Code = countryDto.Code;
                country.Name = countryDto.Name;
                country.CurrencyId = countryDto.CurrencyId;
                _countryService.Update(country);
                return NoContent();
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Remove( int id)
        {
            var currency = await _countryService.GetById(id);
            if (currency != null)
            {
                _countryService.Remove(currency);
                return NoContent();
            }
            return BadRequest();
        }

    }
}
