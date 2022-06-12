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

        public HazardousAsteroidsController(IHazardousAsteroidsService hazardousAsteroidsService)
        {
            _hazardousAsteroidsService = hazardousAsteroidsService ?? throw new ArgumentNullException(nameof(hazardousAsteroidsService));
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
                return new OkObjectResult(apiResponse);
            }
            catch (UnexpectedResponseException exception)
            {
                return StatusCode(500, exception.Message);
            }
          

        }
    }
}
