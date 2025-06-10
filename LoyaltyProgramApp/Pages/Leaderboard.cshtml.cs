namespace LoyaltyProgramApp;

using Microsoft.AspNetCore.Mvc.RazorPages;

public class LeaderboardModel : PageModel
{
    private readonly AppDbContext _db;
    public LeaderboardModel(AppDbContext db) => _db = db;

    public List<User> Users { get; set; } = new();

    public void OnGet()
    {
        Users = _db.Users
            .OrderByDescending(u => u.Points)
            .Take(10)
            .ToList();
    }
}
