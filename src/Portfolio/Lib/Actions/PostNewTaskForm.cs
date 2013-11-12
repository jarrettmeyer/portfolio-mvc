using System;
using System.Web;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;
using Portfolio.Web.ViewModels;

namespace Portfolio.Lib.Actions
{
    public class PostNewTaskForm : AbstractAction
    {
        private readonly IClock clock;
        private TaskInputModel form;
        private readonly HttpRequestBase httpRequest;
        private readonly IRepository repository;
        private Status status;
        private Task task;
        private TaskStatus taskStatus;

        public PostNewTaskForm(IRepository repository, HttpRequestBase httpRequest, IClock clock)
        {
            this.repository = repository;
            this.httpRequest = httpRequest;
            this.clock = clock;
        }

        public override void Execute()
        {
            FetchDefaultStatus();
            CreateNewTask();
            WriteSuccessMessage();            
        }

        public PostNewTaskForm WithForm(TaskInputModel form)
        {
            this.form = form;
            return this;
        }

        private void CreateNewTask()
        {
            task = form.GetTask();
            task.CurrentStatus = status;
            task.CreatedAt = clock.Now;
            task.UpdatedAt = clock.Now;

            taskStatus = new TaskStatus
            {
                Comment = "",
                CreatedAt = clock.Now,
                IPAddress = httpRequest.UserHostAddress,
                IsCompleted = status.IsCompleted,
                ToStatus = status
            };
            task.AddStatus(taskStatus);

            repository.Add(task);
            repository.SaveChanges();
        }

        private void FetchDefaultStatus()
        {
            status = repository.FindOne<Status>(s => s.IsDefaultStatus);
            if (status == null)
                throw new NullReferenceException("Unable to fetch default status.");
        }

        private void WriteSuccessMessage()
        {
            var flashMessageCollection = new FlashMessageCollection(TempData);
            flashMessageCollection.AddSuccessMessage(string.Format("Successfully created new task: {0}", task.Title));
        }
    }
}