using System.ComponentModel.DataAnnotations;

namespace HW_FutureMe.Models
{
    public class Letter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Неверный формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите текст письма")]
        [MinLength(10, ErrorMessage = "Письмо должно содержать минимум 10 символов")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Выберите дату отправки")]
        [DataType(DataType.Date)]
        public DateTime SendDate { get; set; }

        
        public bool IsPublic { get; set; } = false;
    }
}
