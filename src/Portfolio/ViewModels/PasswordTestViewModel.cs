using System.ComponentModel.DataAnnotations;
using Portfolio.Lib;

namespace Portfolio.ViewModels
{
    public class PasswordTestViewModel
    {
        public PasswordTestViewModel()
        {
            Password = "";
        }

        public PasswordTestViewModel(string plainTextPassword, IPasswordUtility passwordUtility)
        {
            this.HashedPassword = passwordUtility.HashText(plainTextPassword);
        }

        public string HashedPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}