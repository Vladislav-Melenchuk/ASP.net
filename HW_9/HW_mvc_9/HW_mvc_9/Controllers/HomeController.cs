using System.Diagnostics;
using HW_mvc_9.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_mvc_9.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
