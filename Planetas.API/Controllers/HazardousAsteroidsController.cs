using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planetas.API.Models;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Exceptions;
using Planetas.ApplicationCore.Interfaces;

namespace Planetas.API.Controllers
{
    public class HazardousAsteroidsController : ControllerBase
    {
        private readonly IHazardousAsteroidsService _hazardousAsteroidsService;
        private readonly IMapper _mapper;
        public HazardousAsteroidsController(IHazardousAsteroidsService hazardousAsteroidsService, IMapper mapper)
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
                var apiResponse = await _hazardousAsteroidsService.GetHazardousAsteroids(hazardousAsteroidsFilter.FromDate, hazardousAsteroidsFilter.ToDate);

                var nearObjects = apiResponse.NearObjects.Values.SelectMany(no => no);

                var filterDto = new HazardousAsteroidsRequestDto(hazardousAsteroidsFilter.PlanetName, hazardousAsteroidsFilter.PageNumber, hazardousAsteroidsFilter.PageSize);

                var hazardousAsteroidsFilterData = _hazardousAsteroidsService.FilterNearObjects(nearObjects, filterDto);

                var hazardousAsteroids = _mapper.Map<IEnumerable<HazardousAsteroid>>(hazardousAsteroidsFilterData.Data);

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
