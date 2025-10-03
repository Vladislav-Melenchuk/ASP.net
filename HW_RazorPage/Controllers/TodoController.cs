using HW_RazorPage.Data;
using HW_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW_RazorPage.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _db;

        public TodoController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _db.Todos.OrderBy(t => t.IsCompleted).ThenByDescending(t => t.CreatedAt).ToListAsync();
            return View(todos);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                var todos = await _db.Todos.ToListAsync();
                return View("Index", todos);
            }

            item.CreatedAt = DateTime.UtcNow;
            _db.Todos.Add(item);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return NotFound();
            return View(todo);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem model)
        {
            if (!ModelState.IsValid) return View(model);

            var todo = await _db.Todos.FindAsync(model.Id);
            if (todo == null) return NotFound();

            todo.Title = model.Title;
            todo.IsCompleted = model.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Toggle(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            todo.IsCompleted = !todo.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
