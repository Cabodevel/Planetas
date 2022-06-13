using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Planetas.Web.Helpers;
using Planetas.Web.Models;

namespace Planetas.Web.Controllers
{
    public class HazardousAsteroidsController : Controller
    {
        private readonly string _apiUrl;
        private readonly IHttpHandler _httpHandler;
        public HazardousAsteroidsController(IConfiguration configuration, IHttpHandler httpHandler)
        {
            _apiUrl = configuration?.GetSection("AsteroidsApiUrl")?.Value ?? throw new ArgumentException(nameof(configuration));
            _httpHandler = httpHandler ?? throw new ArgumentNullException(nameof(httpHandler));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Datatable(DataTableAjaxModel request)
        {
            var queryUrl = MapRequestUrl(request);

            var response = await _httpHandler.Get(queryUrl);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiData = JsonConvert.DeserializeObject<HazardousAsteroidsApiResponse>(responseContent);

            return new JsonResult(new DataTableResponse<HazardousAsteroid>
            {
                Draw = request.Draw,
                RecordsFiltered = apiData.TotalItemsCount,
                RecordsTotal = apiData.TotalItemsCount,
                Data = apiData.HazardousAsteroids
            });
        }

        private string MapRequestUrl(DataTableAjaxModel request)
        {
            var page = 0;

            if (request.Length > 0)
            {
                page = request.Start / request.Length;
            }

            var queryParameters = new Dictionary<string, string>
            {
                { "planetName", request.Planet },
                { "fromDate", request.FromDate?.ToString("O") },
                { "toDate", request.ToDate?.ToString("O") },
                { "pageNumber", page.ToString() },
                { "pageSize", request.Length.ToString() }
            };


            var queryUrl = new Uri(QueryHelpers.AddQueryString(_apiUrl, queryParameters));

            return queryUrl.ToString();
        }
    }
}
