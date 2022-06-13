using Microsoft.AspNetCore.Mvc;
using Planetas.Web.Models;

namespace Planetas.Web.Controllers
{
    public class HazardousAsteroidsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new HazardousAsteroidsViewModel());
        }
    }
}
