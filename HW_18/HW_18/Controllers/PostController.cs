using HW_18.Data;
using HW_18.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class PostController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext _context;

    public PostController(UserManager<User> userManager, ApplicationContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        
        var friends = await _context.Friends
            .Where(f => f.IsConfirmed && (f.UserId == userId || f.FriendId == userId))
            .Select(f => f.UserId == userId ? f.FriendId : f.UserId)
            .ToListAsync();

        
        var posts = await _context.Posts
            .Include(p => p.User)
            .Where(p =>
                p.Visibility == PostVisibility.Public ||
                (p.Visibility == PostVisibility.Private && p.UserId == userId) ||
                (p.Visibility == PostVisibility.Friends && friends.Contains(p.UserId))
            )
            .ToListAsync();

        return View(posts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Post post)
    {
        post.UserId = _userManager.GetUserId(User);
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
