using API.Installers.Interfaces;
using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installers.InstallServices
{
    public class DIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddApplication();
            services.AddInfrastructure();
        }
    }
}
