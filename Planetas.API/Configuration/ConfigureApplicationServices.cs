using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;

namespace Planetas.API.Configuration
{
    internal static class ConfigureApplicationServices
    {
        internal static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHazardousAsteroidsService, HazardousAsteroidsService>();
        }
    }
}
