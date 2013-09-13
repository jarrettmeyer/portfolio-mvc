using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public abstract class CreateTask : AbstractCommand
    {
        public Task Task { get; set; }
    }
}
