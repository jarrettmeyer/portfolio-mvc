using System.ComponentModel.DataAnnotations;

namespace Portfolio.Lib.ViewModels
{
    public class Credentials
    {
        public Credentials() { }

        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
    }
}