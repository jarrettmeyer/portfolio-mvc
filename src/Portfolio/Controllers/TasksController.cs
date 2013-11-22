using System;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var tasks = Repository.Instance.FindAll<Task>().OrderBy(t => t.Id);
            var model = new TaskListViewModel(tasks);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var task = Repository.Instance.Load<Task>(id);
            var model = new TaskViewModel(task);
            return View("Show", model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new TaskInputModel();
            return View("New", model);
        }

        [HttpPost]
        public ActionResult New(TaskInputModel model)
        {
            CheckModelState(() =>
            {
                FlashMessages.AddErrorMessage("There is something wrong with the form. Please correct the errors and try again.");
                return View("New", model);
            });
            try
            {
                var task = CreateNewTask(model);
                FlashMessages.AddSuccessMessage(string.Format("Created new task: {0}", task.Title));
                return RedirectToAction("Show", new { id = task.Id });
            }
            catch (Exception e)
            {
                FlashMessages.AddErrorMessage(e.Message);
                return View("New", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var task = Repository.Instance.Load<Task>(id);
            var model = new TaskInputModel(task);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(TaskInputModel model)
        {
            CheckModelState(() => View("Edit", model));
            using (var transaction = Repository.Instance.BeginTransaction())
            {
                Task task = Repository.Instance.Load<Task>(model.Id);
                task.Title = model.Title;
                task.Description = model.Description;
                task.DueOn = model.DueOn.SafeParseDateTime();
                transaction.Commit();
                return RedirectToAction("Show", new { id = model.Id });            
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (var transaction = Repository.Instance.BeginTransaction())
            {
                Task task = Repository.Instance.Load<Task>(id);
                Repository.Instance.Delete(task);
                transaction.Commit();
                return new EmptyResult();
            }
        }

        private static Task CreateNewTask(TaskInputModel model)
        {
            using (var txn = Repository.Instance.BeginTransaction())
            {
                Task task = new Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    DueOn = model.DueOn.SafeParseDateTime(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                
                Repository.Instance.Add(task);
                txn.Commit();
                return task;
            }
        }
    }
}
