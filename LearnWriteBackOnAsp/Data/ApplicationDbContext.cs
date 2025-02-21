using LearnWriteBackOnAsp.ModelsDbContext;
using Microsoft.EntityFrameworkCore;

namespace LearnWriteBackOnAsp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}