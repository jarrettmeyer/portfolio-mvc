using System.ComponentModel.DataAnnotations;

namespace Portfolio.Lib.ViewModels
{
    public class PasswordTestViewModel
    {
        public string HashedPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}