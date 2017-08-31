using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnWords.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Нужно указало логин ")]
        [StringLength(30, ErrorMessage = "Логин слишком большой")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Нужно указать пароль")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 30 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}