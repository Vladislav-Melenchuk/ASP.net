﻿namespace HW_Forms.Models
{
    public class User
    {
        public int Id { get; set; }   

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string CreditCardNumber { get; set; }

        public string Website { get; set; }

        public string PasswordHash { get; set; }
    }
}
