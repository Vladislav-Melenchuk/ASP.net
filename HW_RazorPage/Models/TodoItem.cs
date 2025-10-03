using System.ComponentModel.DataAnnotations;

namespace HW_RazorPage.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Display(Name = "Назва завдання")]
        [Required(ErrorMessage = "Поле «Назва завдання» є обов’язковим.")]
        [MinLength(2, ErrorMessage = "Мінімальна довжина — 2 символи.")]
        [StringLength(200, ErrorMessage = "Максимальна довжина — 200 символів.")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Виконано")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Створено")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Оновлено")]
        public DateTime? UpdatedAt { get; set; }
    }
}
