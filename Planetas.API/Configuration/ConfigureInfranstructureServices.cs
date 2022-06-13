using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Services;

namespace Planetas.API.Configuration
{
    public static class ConfigureInfranstructureServices
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHttpRequestService, HttpRequestService>();
            serviceCollection.AddScoped<IHazardousAsteroidsService, HazardousAsteroidsService>();
        }
    }
}
