using HW_RazorPage.Data;
using HW_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HW_RazorPage.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public TodoItem Input { get; set; } = new();

        public async Task<IActionResult> OnGet(int id)
        {
            var todo = await _db.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (todo == null) return NotFound();
            Input = todo;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var todo = await _db.Todos.FindAsync(Input.Id);
            if (todo == null) return NotFound();

            todo.Title = Input.Title;
            todo.IsCompleted = Input.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
