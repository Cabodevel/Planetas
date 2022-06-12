namespace Planetas.API.Configuration.Options
{
    internal static class ConfigureOptions
    {
        internal static void Configure(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<NasaApiOptions>(configuration.GetSection(nameof(NasaApiOptions)));
        }
    }
}
