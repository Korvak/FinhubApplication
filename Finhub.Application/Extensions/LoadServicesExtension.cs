using Finhub.Application.Services;
using Finhub.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Finhub.Application.Extensions
{
    public static class LoadServicesExtension
    {
        public static IServiceCollection LoadServices(this IServiceCollection services, IConfiguration _configuration)
        {
            //finhub services
            services.AddScoped<IFinnhubCompanyProfileService, FinnhubCompanyProfileService>();
            services.AddScoped<IFinnhubStockPriceQuoteService, FinnhubStockPriceQuoteService>();
            services.AddScoped<IFinnhubSearchStocksService, FinnhubSearchStocksService>();
            services.AddScoped<IFinnhubStocksService, FinnhubStocksService>();
            //stock services
            services.AddScoped<IStocksService, StocksService>();
            return services;
        }
    }

}
