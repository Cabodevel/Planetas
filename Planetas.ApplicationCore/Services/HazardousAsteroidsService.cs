using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;

namespace Planetas.ApplicationCore.Services
{
    public class HazardousAsteroidsService : IHazardousAsteroidsService
    {
        public Task<NasaApiResponseDto> GetHazardousAsteroids(DateTime? start, DateTime? end)
        {
            throw new NotImplementedException();
        }
    }
}
