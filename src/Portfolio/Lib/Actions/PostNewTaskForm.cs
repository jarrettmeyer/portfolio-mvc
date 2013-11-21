using System;
using System.Web;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Actions
{
    public class PostNewTaskForm : AbstractAction
    {
        private readonly IClock clock;
        private TaskInputModel form;
        private readonly HttpRequestBase httpRequest;
        private readonly IRepository repository;
        private Task task;

        public PostNewTaskForm(IRepository repository, HttpRequestBase httpRequest, IClock clock)
        {
            this.repository = repository;
            this.httpRequest = httpRequest;
            this.clock = clock;
        }

        public Task Task
        {
            get { return task; }
        }

        public override void Execute()
        {
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
            task.CreatedAt = clock.Now;
            task.UpdatedAt = clock.Now;

            repository.Add(task);
            repository.SaveChanges();
        }

        private void WriteSuccessMessage()
        {
            var flashMessageCollection = new FlashMessageCollection(TempData);
            flashMessageCollection.AddSuccessMessage(string.Format("Successfully created new task: {0}", task.Title));
        }
    }
}