using Microsoft.Extensions.DependencyInjection;
using Sbsc.API.Interfaces;
using Sbsc.API.Repositories;

namespace API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGeneralRepository, GeneralRepository>();

            return services;
        }
    }
}