using HW_Forms.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_Forms.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>(); 
    }
}
