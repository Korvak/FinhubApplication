using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Finhub.Application.Extensions
{
    public static class LoadServicesExtension
    {
        public static IServiceCollection LoadServices(this IServiceCollection services, IConfiguration _configuration)
        {
            return services;
        }
    }

}
