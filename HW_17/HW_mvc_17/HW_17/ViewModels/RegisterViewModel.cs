using System.ComponentModel.DataAnnotations;

namespace HW_17.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }
    }
}
