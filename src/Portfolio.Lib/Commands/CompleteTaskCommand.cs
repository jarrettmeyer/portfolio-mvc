using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CompleteTaskCommand : ICommand<Task>
    {
        public CompleteTaskCommand() { }

        public CompleteTaskCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
