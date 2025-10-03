using System.Diagnostics;
using HW_Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_Auth.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
