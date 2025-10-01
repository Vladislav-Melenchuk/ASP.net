using System.ComponentModel.DataAnnotations;

namespace HW_ViewComponent.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле «Название» является обязательным.")]
        [Display(Name = "Название")]
        [MinLength(2, ErrorMessage = "Название должно содержать минимум 2 символа.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле «Автор» является обязательным.")]
        [Display(Name = "Автор")]
        [MinLength(2, ErrorMessage = "Имя автора должно содержать минимум 2 символа.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле «Жанр» является обязательным.")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;

        [Range(0, 100000, ErrorMessage = "Цена должна быть от 0 до 100000.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        // Навигация: у книги могут быть комментарии
        public List<Comment> Comments { get; set; } = new();
    }
}
