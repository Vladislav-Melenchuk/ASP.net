using HW_FutureMe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HW_FutureMe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Letter> Letters { get; set; }
    }
}
