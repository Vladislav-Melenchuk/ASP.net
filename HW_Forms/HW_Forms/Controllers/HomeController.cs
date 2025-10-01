using Microsoft.AspNetCore.Mvc;

namespace HW_Forms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
