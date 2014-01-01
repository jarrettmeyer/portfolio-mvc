using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CompleteTaskCommand : ICommand<Task>
    {
        public int Id { get; set; }
    }
}
