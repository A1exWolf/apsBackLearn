using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnWriteBackOnAsp.ModelsDbContext;

public class User
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string? Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(8)]
    public string Password { get; set; }
    
    [Range(7, 70, ErrorMessage = "Age must be between 7 and 70")]
    public int? Age { get; set; }
    [Required, DefaultValue(Role.User)]
    public Role Role { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public enum Role
{
    User,
    TechSupport,
    Admin
}
