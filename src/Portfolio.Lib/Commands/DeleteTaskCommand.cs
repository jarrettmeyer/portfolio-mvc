using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class DeleteTaskCommand : ICommand<Task>
    {
        public DeleteTaskCommand() { }

        public DeleteTaskCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
