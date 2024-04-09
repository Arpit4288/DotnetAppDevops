using DotnetPipelineApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DotnetPipelineApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hey , This is Aparna Joshi";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Check if Activity.Current is null or HttpContext is null
            string requestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier ?? "Unknown";

            // Initialize ErrorViewModel with a non-null RequestId
            var errorViewModel = new ErrorViewModel { RequestId = requestId };

            return View(errorViewModel);
        }
    }
}
