using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HW_Forms.ViewData
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(20, ErrorMessage = "Логин не должен превышать 20 символов")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Разрешены только буквы, цифры и подчеркивания")]
        [Remote(action: "CheckUsername", controller: "Account", ErrorMessage = "Такой логин уже существует")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100, ErrorMessage = "Пароль не должен превышать 100 символов", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(100)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }

        [Range(18, 100, ErrorMessage = "Возраст должен быть от 18 до 100 лет")]
        public int Age { get; set; }

        [CreditCard(ErrorMessage = "Некорректный номер кредитной карты")]
        public string CreditCardNumber { get; set; }

        [Url(ErrorMessage = "Некорректный формат URL")]
        public string Website { get; set; }

        [ValidateNever]
        public bool TermsOfService { get; set; }
    }
}
