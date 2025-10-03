using HW_FutureMe.Data;
using HW_FutureMe.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_FutureMe.Controllers
{
    public class LetterController : Controller
    {
        private readonly AppDbContext _context;

        public LetterController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var letters = _context.Letters.Where(l => l.IsPublic).ToList();
            return View(letters);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Letters.Add(letter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(letter);
        }
    }
}
