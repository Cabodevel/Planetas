using Microsoft.AspNetCore.Mvc;
using Planetas.Web.Models;

namespace Planetas.Web.Controllers
{
    public class HazardousAsteroidsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Datatable(DataTableAjaxModel request)
        {

            return new JsonResult(new DataTableResponse<HazardousAsteroid>
            {
                Draw = 1,
                RecordsFiltered = 1,
                RecordsTotal = 10,
                Data = new List<HazardousAsteroid> { new HazardousAsteroid { Date = "2016-01-01", Diameter = 0.15M, Name = "Test", Speed = 10M } }
            });
        }
    }
}
