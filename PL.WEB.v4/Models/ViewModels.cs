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
        [Display(Name = "Email:")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        [Remote("CheckEmail2", "Account", ErrorMessage = "This Email not in use.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }

    public class RegistrationViewModel
    {
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        [Remote("CheckEmail", "Account", ErrorMessage = "This Email in use!")]
        public string Email { get; set; }

        [Display(Name = "Login:")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+", ErrorMessage = "Incorrect Login")]
        [Remote("CheckLogin", "Account", ErrorMessage = "this login is used")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm:")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }

    public class FileViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;

        public bool Received { get; set; }

    }
    public class UserViewModel
    {

    }
}