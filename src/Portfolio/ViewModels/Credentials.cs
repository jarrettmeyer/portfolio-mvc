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

        public string Password { get; set; }

        public string Username { get; set; }
    }
}