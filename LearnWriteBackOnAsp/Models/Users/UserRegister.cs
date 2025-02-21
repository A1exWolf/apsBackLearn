using System.ComponentModel.DataAnnotations;
using LearnWriteBackOnAsp.ModelsDbContext;

namespace LearnWriteBackOnAsp.Models.Users;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public class UserRegister
{
    public string? UserName { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    public Role Role { get; set; }
}
