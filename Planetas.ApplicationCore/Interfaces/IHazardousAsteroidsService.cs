using Planetas.ApplicationCore.Dtos;

namespace Planetas.ApplicationCore.Interfaces
{
    public interface IHazardousAsteroidsService
    {
        Task<NasaApiResponseDto> GetHazardousAsteroids(DateTime? start, DateTime? end);
    }
}
