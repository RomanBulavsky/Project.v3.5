using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFoundation.PL.WEB.Models
{

        public class LogOnModel
        {
            [Required(ErrorMessage = "The field can not be empty!")]
            [Display(Name = "Enter your e-mail")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The field can not be empty!")]
            [DataType(DataType.Password)]
            [Display(Name = "Enter your password")]
            public string Password { get; set; }

            [Display(Name = "Remember password?")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
        {
            [Display(Name = "Enter your Email")]
            [Required(ErrorMessage = "The field can not be empty!")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
            [Remote("CheckEmail", "Account", ErrorMessage = "This Email in use!!!!!!")]
            public string Email { get; set; }

            [Display(Name = "Enter your Login")]
            [Required(ErrorMessage = "The field can not be empty!")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+", ErrorMessage = "Некорректный Login")]
            [Remote("CheckLogin", "Account", ErrorMessage = "This Login in use!!!!!!")] 
            public string Login { get; set; }

            [Required(ErrorMessage = "Enter your password")]
            [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Enter your password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm the password")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm the password")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
            public string ConfirmPassword { get; set; }

        }


        public enum Role2
        {
            Administrator = 1,
            User
        }

    
}