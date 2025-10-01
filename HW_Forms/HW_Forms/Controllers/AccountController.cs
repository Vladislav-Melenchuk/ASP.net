using HW_Forms.Data;
using HW_Forms.Models;
using HW_Forms.ViewData;
using Microsoft.AspNetCore.Mvc;

namespace HW_Forms.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_context.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Имя пользователя уже занято");
                    return View(model);
                }

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Age = model.Age,
                    CreditCardNumber = model.CreditCardNumber,
                    Website = model.Website,
                    PasswordHash = hashedPassword
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                ViewBag.Message = "Вы успешно зарегистрировались и авторизованы!";
                return View("Success");
            }

            return View(model);
        }
    }
}
