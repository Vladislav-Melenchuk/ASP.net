﻿using Microsoft.AspNetCore.Identity;

namespace Practice2.Models
{
    public class User : IdentityUser
    {
        public int PulicationsCount { get; set; }
        public string? Name { get; set; }
    }
}
