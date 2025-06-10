namespace LoyaltyProgramApp;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _db;
    public RegisterModel(AppDbContext db) => _db = db;

    [BindProperty]
    public InputModel Input { get; set; } = new();
    public string Message { get; set; } = string.Empty;

    public record InputModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public void OnGet() {}

    public IActionResult OnPost()
    {
        var user = _db.Users.FirstOrDefault(u => u.Email == Input.Email);
        if (user == null)
        {
            user = new User
            {
                Name = Input.Name,
                Email = Input.Email,
                MobileNumber = Input.MobileNumber,
                Age = Input.Age,
                Points = 0
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            Message = "User created";
        }
        else
        {
            Message = "User already exists";
        }
        Response.Cookies.Append("userEmail", user.Email);
        return Page();
    }
}
