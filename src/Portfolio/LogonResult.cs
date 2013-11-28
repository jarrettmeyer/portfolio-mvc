using Portfolio.Models;

namespace Portfolio
{
    public class LogonResult
    {
        public bool IsSuccessful { get; set; }

        public User User { get; set; }
    }
}