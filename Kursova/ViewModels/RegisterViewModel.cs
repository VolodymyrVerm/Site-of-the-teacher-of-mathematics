using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kursova.ViewModels
{
    public class RegisterViewModel
    {
        
        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Клас")]
        public int NumberOfClass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        public string PasswordConfirm { get; set; }
    }
}