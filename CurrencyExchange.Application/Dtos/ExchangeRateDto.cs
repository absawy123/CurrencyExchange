namespace CurrencyExchange.Application.Dtos
{
    public class ExchangeRateDto
    {
        public string CurrencyName { get; set; } = null!;
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
