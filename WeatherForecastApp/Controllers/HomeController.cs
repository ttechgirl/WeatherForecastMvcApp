using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWeatherService _weatherService;

        public HomeController(ILogger<HomeController> logger,  IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;

        }

        public IActionResult Index()
        {
            var city = new OpenWeatherResponseModel();
            return View(city);
        }

        //Get city weather details
        public async Task<IActionResult> GetCity(OpenWeatherResponseModel city)
        {

            if (city == null)
            {
                return View("notfound", city);
            }


            var result = await _weatherService.GetCity(city.name);

            //checking validation state
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(result), "City weather details not found");

            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}