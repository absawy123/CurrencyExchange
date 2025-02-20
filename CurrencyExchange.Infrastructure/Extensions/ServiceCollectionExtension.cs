using CountryData.Standard;
using CurrencyExchange.Application.Services;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.persistence;
using CurrencyExchange.Infrastructure.persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,string connectionstring)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(ICountryRepo), typeof(CountryRepo));
            services.AddScoped(typeof(ICurrencyRepo), typeof(CurrencyRepo));
            services.AddScoped(typeof(IExchangeRateRepo), typeof(RateRepo));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<CountryService>();
            services.AddScoped<CurrencyService>();
            services.AddScoped<ExchangeRateService>();

            return services;
        }

        public static void SeedData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                if (!context.Countries.Any())
                {
                    var countriesList = new List<CurrencyExchange.Core.Entities.Country>();
                    var currenciesList = new List<CurrencyExchange.Core.Entities.Currency>();

                    var helper = new CountryHelper();
                    var countriesData = helper.GetCountryData().ToList();

                    foreach(var countryData in countriesData)
                    {
                        var countryCurrency = countryData.Currency?.FirstOrDefault();
                        if (countryCurrency != null && !string.IsNullOrEmpty(countryCurrency.Name))
                        {
                            CurrencyExchange.Core.Entities.Currency currency = new CurrencyExchange.Core.Entities.Currency()
                            {
                                Name = countryCurrency.Name,
                                Code = countryCurrency.Code,
                            };

                            currenciesList.Add(currency);
                        }
                    }

                    context.Currencies.AddRangeAsync(currenciesList);
                    context.SaveChanges();

                    foreach (var countryData in countriesData)
                    {
                        if (countryData.Currency != null)
                        {
                            var currencyCode = helper.GetCurrencyCodesByCountryCode(countryData.CountryShortCode)
                                .FirstOrDefault()?.Code;
                            CurrencyExchange.Core.Entities.Country country = new CurrencyExchange.Core.Entities.Country()
                            {
                                Name = countryData.CountryName,
                                Code = countryData.CountryShortCode,
                                CurrencyId = context.Currencies.Where(c => c.Code == currencyCode).FirstOrDefault().Id
                            };

                            countriesList.Add(country);
                        }
                    }

                    context.Countries.AddRangeAsync(countriesList);
                    context.SaveChanges();
                }

            }
        }



    }
}
