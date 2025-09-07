using System.Diagnostics;
using HW_mvc_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_mvc_1.Controllers
{
    public class HomeController : Controller
    {

        [ViewData]

        public string ViewDataMessage { get; set; }
        public IActionResult Index()
        {
            ViewDataMessage = "Hello from ViewData!";
            ViewBag.Hello = "Hello from ViewBag!";
            return View(model: "Hello from model");
        }


        public IActionResult Exchange()
        {
            return View();
        }




    }
}
