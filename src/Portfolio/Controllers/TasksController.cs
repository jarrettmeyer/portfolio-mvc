using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Lib;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        readonly IMediator mediator;

        public TasksController(IMediator mediator)
        {
            Contract.Requires<ArgumentNullException>(mediator != null);
            this.mediator = mediator;
            InitializeTagSelectList();
        }

        [HttpPost]
        public ActionResult Complete(CompleteTaskCommand command)
        {            
            Task task = mediator.Send(command);
            this.Flash("success", string.Format("Completed task: {0}", task.Title));
            return Json(new { success = true });
        }

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteTaskCommand command)
        {
            return new DeleteResponder(this)
                .RespondWith(mediator, command);
        }

        [HttpGet]
        public ActionResult Edit(TaskByIdQuery query)
        {            
            var task = mediator.Request(query);
            var model = new TaskInputModel(task);
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskInputModel model)
        {
            CheckModelState(() => OnInvalidTaskForm("Edit", model));
            var task = mediator.Send(model.ToUpdateTaskCommand());            
            this.Flash("success", string.Format("Updated task: {0}", task.Title));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var tasks = mediator.Request(new OpenTasksQuery());
            var model = new TaskListViewModel(tasks);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new TaskInputModel();
            return View("New", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(TaskInputModel model)
        {
            CheckModelState(() => OnInvalidTaskForm("New", model));
            Task task = mediator.Send(model.ToCreateTaskCommand());
            this.Flash("success", string.Format("Created new task: {0}", task.Title));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Show(TaskByIdQuery query)
        {
            var task = mediator.Request(query);
            var model = new TaskViewModel(task);
            return View("Show", model);
        }

        private void InitializeTagSelectList()
        {
            if (!TagSelectList.IsInitialized)
            {
                var tags = mediator.Request(new ActiveTagsQuery());
                TagSelectList.Initialize(tags);
            }
        }

        private ActionResult OnInvalidTaskForm(string viewName, TaskInputModel model)
        {
            this.Flash("danger", DEFAULT_FORM_ERROR_MESSAGE);
            return View(viewName, model);
        }
    }
}
