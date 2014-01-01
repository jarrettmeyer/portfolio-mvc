using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class DeleteTaskCommand : ICommand<Task>
    {
        public int Id { get; set; }
    }
}
