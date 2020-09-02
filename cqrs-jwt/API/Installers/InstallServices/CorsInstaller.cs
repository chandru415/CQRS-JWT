using API.Installers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installers.InstallServices
{
    public class CorsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });
        }
    }
}
