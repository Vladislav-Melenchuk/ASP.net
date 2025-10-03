using System.ComponentModel.DataAnnotations;

namespace HW_Auth.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть логін")]
        [Display(Name = "Логін")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
