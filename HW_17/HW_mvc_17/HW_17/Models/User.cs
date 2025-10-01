using Microsoft.AspNetCore.Identity;

namespace HW_17.Models
{
    public class User: IdentityUser
    {
        public int Year { get; set; }
    }
}
