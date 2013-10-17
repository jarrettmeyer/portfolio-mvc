using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public abstract class CreateTask : AbstractCommand<CreateTaskRequest, CreateTaskResponse>
    {        
    }

    public class CreateTaskRequest
    {
        private readonly Task task;        

        public CreateTaskRequest(Task task)
        {
            this.task = task;
        }

        public Task Task
        {
            get { return task; }
        }
    }

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
