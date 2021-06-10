using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="Вкажіть ім'я!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Вкажіть прізвище!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Вкажіть логін!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть пароль!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторіть пароль!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
