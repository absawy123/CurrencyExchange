namespace CurrencyExchange.Core.Entities
{
    public class ExchangeRate :BaseEntity
    {
        public int CurrencyId { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}


