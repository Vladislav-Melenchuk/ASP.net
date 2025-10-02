using HW_Cookie.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_Cookie.Controllers
{
    public class BlogController : Controller
    {
        private static List<News> _newsList = new List<News>
        {
            new News { Id = 1, Title = "Первая новость", Content = "Содержимое первой новости", Date = DateTime.Now },
            new News { Id = 2, Title = "Вторая новость", Content = "", Date = DateTime.Now.AddDays(-1) }
        };

        public IActionResult Index()
        {
            var theme = Request.Cookies["theme"] ?? "light";
            ViewBag.Theme = theme;

            return View(_newsList);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var theme = Request.Cookies["theme"] ?? "light";
            ViewBag.Theme = theme;
            return View();
        }

        [HttpPost]
        public IActionResult Settings(string theme)
        {
            Response.Cookies.Append("theme", theme, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            });

            return RedirectToAction("Index");
        }
    }
}
