using Portfolio.Lib.DTOs;

namespace Portfolio.API.ApiModels
{
    public class PostSessionRequest
    {
        public string Password { get; set; }

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