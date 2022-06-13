using Planetas.ApplicationCore.Dtos;

namespace Planetas.ApplicationCore.Interfaces
{
    public interface IHazardousAsteroidsApplicationService
    {
        Task<HazardousAsteroidsFilteredDataDto> FilterNearObjects(HazardousAsteroidsRequestDto filters);
    }
}
