using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planetas.API.Models;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;
using Planetas.Infrastructure.Exceptions;

namespace Planetas.API.Controllers
{
    public class HazardousAsteroidsController : ControllerBase
    {
        private readonly IHazardousAsteroidsApplicationService _hazardousAsteroidsService;
        private readonly IMapper _mapper;
        public HazardousAsteroidsController(IHazardousAsteroidsApplicationService hazardousAsteroidsService, IMapper mapper)
        {
            _hazardousAsteroidsService = hazardousAsteroidsService ?? throw new ArgumentNullException(nameof(hazardousAsteroidsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("ByDate")]
        public async Task<IActionResult> GetHazardousAsteroidsFiltered(HazardousAsteroidsFilter hazardousAsteroidsFilter)
        {
            if (string.IsNullOrWhiteSpace(hazardousAsteroidsFilter?.PlanetName))
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Planet name is required" });
            }

            try
            {
                var filterDto = _mapper.Map<HazardousAsteroidsRequestDto>(hazardousAsteroidsFilter);
                var hazardousAsteroidsFilterData = await _hazardousAsteroidsService.FilterNearObjects(filterDto);
                var hazardousAsteroids = _mapper.Map<IEnumerable<HazardousAsteroidVm>>(hazardousAsteroidsFilterData.Data);
                var response = new HazardousAsteroidsResponse
                {
                    TotalItemsCount = hazardousAsteroidsFilterData.FilteredCount,
                    HazardousAsteroids = hazardousAsteroids
                };

                return new OkObjectResult(response);
            }
            catch (UnexpectedResponseException exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}
