using FacturacionMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FacturacionMvc.Controllers
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

            HttpContext.Session.SetInt32("Error", 1);
            HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
            HttpContext.Session.SetString("Login", string.Empty);

                

           
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}