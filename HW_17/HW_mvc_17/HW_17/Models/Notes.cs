using System.ComponentModel.DataAnnotations;

namespace HW_17.Models
{
    public class Notes
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

       
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
