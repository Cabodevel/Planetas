using Planetas.Infrastructure.Options;

namespace Planetas.API.Configuration
{
    internal static class ConfigureOptions
    {
        internal static void Configure(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<NasaApiOptions>(configuration.GetSection(nameof(NasaApiOptions)));
        }
    }
}
