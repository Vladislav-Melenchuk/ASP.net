using System.ComponentModel.DataAnnotations;

namespace HW_ViewComponent.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        // Простой "гость" без регистрации
        [Required(ErrorMessage = "Имя обязательно.")]
        [Display(Name = "Ваше имя")]
        [MinLength(2, ErrorMessage = "Имя должно содержать минимум 2 символа.")]
        public string AuthorName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Комментарий обязателен.")]
        [Display(Name = "Комментарий")]
        [MinLength(2, ErrorMessage = "Комментарий слишком короткий.")]
        public string Body { get; set; } = string.Empty;

        [Display(Name = "Дата")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигация
        public Book? Book { get; set; }
    }
}
