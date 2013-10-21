using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public class UpdateTaskStatusResponse
    {
        private readonly Task task;

        public UpdateTaskStatusResponse(Task task)
        {
            this.task = task;
        }

        public Task Task
        {
            get { return task; }
        }
    }
}
