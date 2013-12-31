using System.ComponentModel.DataAnnotations;
using Portfolio.Lib.DTOs;

namespace Portfolio.ViewModels
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

        public CredentialsDTO ToDTO()
        {
            return new CredentialsDTO
            {
                PlainTextPassword = Password,
                Username = Username
            };
        }
    }
}