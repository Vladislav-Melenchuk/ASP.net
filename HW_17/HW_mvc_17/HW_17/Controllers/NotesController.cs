using HW_17.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HW_17.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public NotesController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var notes = await _context.Notes
                .Where(n => n.UserId == user.Id)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notes note)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                note.UserId = user.Id;
                note.CreatedAt = DateTime.UtcNow;
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == user.Id);

            if (note == null) return NotFound();

            return View(note);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Notes note)
        {
            var user = await _userManager.GetUserAsync(User);
            var dbNote = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == user.Id);

            if (dbNote == null) return NotFound();

            if (ModelState.IsValid)
            {
                dbNote.Title = note.Title;
                dbNote.Content = note.Content;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == user.Id);

            if (note == null) return NotFound();

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == user.Id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
