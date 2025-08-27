using HW_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HW_4.Controllers
{
    public class HomeController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Name = "Владислав", Email = "vlad@example.com", Age = 20 }
        };

        public IActionResult Index()
        {
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid) return View(user);

            users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(string email)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null) return NotFound();

            return View(user);
        }

        public IActionResult Edit(string email)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(string email, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View(updatedUser);

            user.Name = updatedUser.Name;
            user.Age = updatedUser.Age;
            user.Email = updatedUser.Email;

            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Delete(string email)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                users.Remove(user);
            }

            return RedirectToAction(nameof(Index));
        }

    }

}
