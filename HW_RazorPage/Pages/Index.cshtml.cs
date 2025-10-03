using HW_RazorPage.Data;
using HW_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HW_RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public TodoItem NewTodo { get; set; } = new();

        public List<TodoItem> Todos { get; set; } = new();

        public async Task OnGet()
        {
            Todos = await _db.Todos
                .OrderBy(t => t.IsCompleted)
                .ThenByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                await OnGet();
                return Page();
            }

            NewTodo.CreatedAt = DateTime.UtcNow;
            _db.Todos.Add(NewTodo);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggle(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            todo.IsCompleted = !todo.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
