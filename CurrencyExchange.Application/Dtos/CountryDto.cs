using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.country
{
    public class CountryDto
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int CurrencyId { get; set; }

    }
}
