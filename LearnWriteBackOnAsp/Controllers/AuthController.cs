using LearnWriteBackOnAsp.Data;
using LearnWriteBackOnAsp.Models.Users;
using LearnWriteBackOnAsp.ModelsDbContext;
using LearnWriteBackOnAsp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnWriteBackOnAsp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(ApplicationDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserLogin login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Email == login.Email && u.Password == login.Password);
        if (user == null)
        {
            return NotFound("Пользователь не найден");
        }

        var token = _tokenService.CreateToken(user);
        return Ok(new { user.Email, user.Role, date = DateTime.Now, token });
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser(UserRegister userRegister)
    {
        if (await _context.Users.AnyAsync(u => u.Email == userRegister.Email))
        {
            return BadRequest("Пользователь с такой почтой уже существует");
        }

        var user = new User
        {
            Email = userRegister.Email,
            Password = userRegister.Password,
            Role = userRegister.Role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("RegisterUser", new { id = user.Id }, user);
    }
}