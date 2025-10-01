using HW_ViewComponent.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_ViewComponent.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Book!)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Три товарища", Author = "Эрих Мария Ремарк", Genre = "Роман", Price = 299 },
                new Book { Id = 2, Title = "Мастер и Маргарита", Author = "М. Булгаков", Genre = "Фантастика", Price = 349 },
                new Book { Id = 3, Title = "Трудно быть богом", Author = "Стругацкие", Genre = "Фантастика", Price = 279 },
                new Book { Id = 4, Title = "Преступление и наказание", Author = "Ф. Достоевский", Genre = "Классика", Price = 199 }
            );
        }
    }
}