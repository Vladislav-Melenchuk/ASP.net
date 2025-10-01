using System.Diagnostics;
using HW_ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_ViewComponent.Controllers
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
            return View();
        }

 

    
    }
}
