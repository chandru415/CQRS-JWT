using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}
