using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public class CreateTaskResponse
    {
        private readonly Task task;

        public CreateTaskResponse(Task task)
        {
            this.task = task;
        }

        public Task Task
        {
            get { return task; }
        }
    }
}