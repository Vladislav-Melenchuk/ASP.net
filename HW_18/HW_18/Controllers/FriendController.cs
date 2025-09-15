using HW_18.Data;
using HW_18.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class FriendController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext _context;

    public FriendController(UserManager<User> userManager, ApplicationContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var currentUserId = _userManager.GetUserId(User);
        var users = await _context.Users
            .Where(u => u.Id != currentUserId)
            .ToListAsync();

        var friends = await _context.Friends
            .Where(f => f.UserId == currentUserId || f.FriendId == currentUserId)
            .ToListAsync();

        ViewBag.Friends = friends;
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> SendRequest(string friendId)
    {
        var userId = _userManager.GetUserId(User);

        if (!await _context.Friends.AnyAsync(f =>
            (f.UserId == userId && f.FriendId == friendId) ||
            (f.UserId == friendId && f.FriendId == userId)))
        {
            var friendRequest = new Friend
            {
                UserId = userId,
                FriendId = friendId,
                IsConfirmed = false
            };
            _context.Friends.Add(friendRequest);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmRequest(int id)
    {
        var request = await _context.Friends.FindAsync(id);
        if (request != null)
        {
            request.IsConfirmed = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RejectRequest(int id)
    {
        var request = await _context.Friends.FindAsync(id);
        if (request != null)
        {
            _context.Friends.Remove(request);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
