using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Queries
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