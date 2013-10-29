using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class PostEditTaskForm : AbstractAction
    {
        private TaskInputModel form;
        private UpdateTask query;
        private UpdateTaskRequest request;
        private Task task;

        public PostEditTaskForm(UpdateTask query)
        {
            this.query = query;
        }

        public int Id
        {
            get { return task.Id; }
        }

        public override void Execute()
        {
            task = form.GetTask();
            request = new UpdateTaskRequest
            {
                Task = task
            };
            query.ExecuteQuery(request);            
        }

        public PostEditTaskForm WithForm(TaskInputModel form)
        {
            this.form = form;
            return this;
        }
    }
}