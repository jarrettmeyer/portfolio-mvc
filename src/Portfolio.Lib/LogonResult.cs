using Portfolio.Lib.Models;

namespace Portfolio.Lib
{
    public class LogonResult
    {
        public bool IsSuccessful { get; set; }

        public User User { get; set; }
    }
}