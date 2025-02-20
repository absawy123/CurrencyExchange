namespace CurrencyExchange.Core.Entities
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public ICollection<Country> Countries { get; set; } = null!;
        public ICollection<ExchangeRate> ExchangeRates { get; set; } = null!;
    }
}
