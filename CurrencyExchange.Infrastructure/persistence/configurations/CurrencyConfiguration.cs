using CurrencyExchange.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyExchange.Infrastructure.persistence.configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies").HasKey(c => c.Id);

            builder.HasMany(c => c.Countries).WithOne(co => co.Currency)
                .HasForeignKey(co => co.CurrencyId);

            builder.HasMany(c => c.ExchangeRates).WithOne(ex => ex.Currency)
                .HasForeignKey(ex => ex.CurrencyId);

        }
    }
}
