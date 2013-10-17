using Portfolio.Common;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public abstract class CreateTask : AbstractCommand<CreateTaskRequest, CreateTaskResponse>
    {        
    }

    public class CreateTaskRequest
    {
        private readonly Task task;
        private readonly IUserSettings userSettings;

        public CreateTaskRequest(Task task, IUserSettings userSettings)
        {
            this.task = task;
            this.userSettings = userSettings;
        }

        public Task Task
        {
            get { return task; }
        }

        public IUserSettings UserSettings
        {
            get { return userSettings; }
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
