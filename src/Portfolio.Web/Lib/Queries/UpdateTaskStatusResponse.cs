using Portfolio.Web.Models;

namespace Portfolio.Data.Queries
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
