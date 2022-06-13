using Planetas.Infrastructure.Models;

namespace Planetas.Infrastructure.Interfaces
{
    public interface IHazardousAsteroidsService
    {
        Task<NasaApiResponse> GetHazardousAsteroids(DateTime? fromDate, DateTime? toDate);

    }
}
