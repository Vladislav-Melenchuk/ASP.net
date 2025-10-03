using HW_RazorPage.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HW_RazorPage.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos => Set<TodoItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
