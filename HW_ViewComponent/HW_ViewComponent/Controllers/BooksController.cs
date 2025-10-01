using HW_ViewComponent.Data;
using HW_ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW_ViewComponent.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int bookId, string authorName, string body)
        {
            if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(body))
            {
                TempData["Error"] = "Все поля обязательны.";
                return RedirectToAction(nameof(Details), new { id = bookId });
            }

            var comment = new Comment
            {
                BookId = bookId,
                AuthorName = authorName,
                Body = body,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = bookId });
        }
    }
}
