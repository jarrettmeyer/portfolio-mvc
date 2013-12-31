namespace Portfolio.Lib.DTOs
{
    public class CredentialsDTO
    {
        public CredentialsDTO()
        {            
        }

        public CredentialsDTO(string username, string plainTextPassword)
        {
            this.Username = username;
            this.PlainTextPassword = plainTextPassword;
        }

        public string PlainTextPassword { get; set; }

        public string Username { get; set; }
    }
}
