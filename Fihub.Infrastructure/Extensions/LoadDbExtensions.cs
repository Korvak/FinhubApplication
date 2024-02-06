using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Finhub.Infrastructure.DbContexts;

namespace Finhub.Infrastructure.Extensions
{
    public static class LoadDbExtensions
    {
        public static IServiceCollection LoadDbContext(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StockMarketDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }



    }
}
