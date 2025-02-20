namespace CurrencyExchange.Core.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

    }
}
