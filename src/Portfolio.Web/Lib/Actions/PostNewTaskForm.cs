using System.Web;
using System.Web.Mvc;
using Portfolio.Common;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class PostNewTaskForm : AbstractAction
    {
        private readonly IClock clock;
        private readonly CreateTask createTask;
        private CreateTaskRequest createTaskRequest;
        private CreateTaskResponse createTaskResponse;
        private TaskInputModel form;
        private readonly HttpRequestBase httpRequest;
        private RedirectToRouteResult redirectToRouteResult;
        private Task task;

        public PostNewTaskForm(CreateTask createTask, HttpRequestBase httpRequest, IClock clock)
        {
            this.createTask = createTask;
            this.httpRequest = httpRequest;
            this.clock = clock;
        }

        public CreateTaskRequest CreateTaskRequest
        {
            get { return createTaskRequest; }
        }

        public override void Execute()
        {
            CreateNewTask();
            InitializeRedirectToRouteResult();            
        }

        public PostNewTaskForm WithForm(TaskInputModel form)
        {
            this.form = form;
            return this;
        }

        private void CreateNewTask()
        {
            task = new Task
            {
                Category = null,
                Description = form.Description,
                DueOn = form.DueOn.SafeParseDateTime()
            };
            createTaskRequest = new CreateTaskRequest(task, httpRequest.UserHostAddress, clock.Now);
            createTaskResponse = createTask.ExecuteQuery(createTaskRequest);
        }

        private void InitializeRedirectToRouteResult()
        {
            redirectToRouteResult = new RedirectToRouteResultBuilder()
                .Controller("Tasks")
                .Action("Show")
                .Id(createTaskResponse.Task.Id)
                .RedirectToRouteResult;
            OnSuccess = () => redirectToRouteResult;
        }
    }
}