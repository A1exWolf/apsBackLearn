using System.ComponentModel.DataAnnotations;

namespace LearnWriteBackOnAsp.Models.Users;

public class UserLogin
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}

