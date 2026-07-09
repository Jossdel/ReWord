using Microsoft.EntityFrameworkCore;
using reword.src.Entities;

namespace reword.src.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
public DbSet<Users> Users { get; set; }

}