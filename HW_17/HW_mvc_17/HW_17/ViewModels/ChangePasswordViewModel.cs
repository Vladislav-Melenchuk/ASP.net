using System.ComponentModel.DataAnnotations;

namespace HW_17.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
