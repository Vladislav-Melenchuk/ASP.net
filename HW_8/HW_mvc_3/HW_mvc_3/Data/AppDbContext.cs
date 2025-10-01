using HW_mvc_3.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_mvc_3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

       



    }
}
