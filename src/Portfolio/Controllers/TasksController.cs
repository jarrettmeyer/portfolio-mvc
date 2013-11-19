using System;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Actions;
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
            var action = ActionResolver.GetAction<GetEditTaskView>()
                .ForId(id);
            action.OnSuccess = () => View("Edit", action.Form);
            return new ActionResultWrapper(action);
        }

        [HttpPost]
        public ActionResult Edit(TaskInputModel model)
        {
            var action = ActionResolver.GetAction<PostEditTaskForm>()
                .WithForm(model);
            action.OnSuccess = () => RedirectToAction("Show", new { id = action.Id });
            action.OnError = () => View("Edit", model);
            return new ActionResultWrapper(action);            
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var action = ActionResolver
                .GetAction<DeleteTask>()
                .ForId(id);            
            return new ActionResultWrapper(action);
        }

        private static Task CreateNewTask(TaskInputModel model)
        {
            Task task;
            using (var txn = Repository.Instance.BeginTransaction())
            {
                Status status = Repository.Instance.FindOne<Status>(s => s.IsDefaultStatus);
                Category category = null;
                if (model.SelectedCategory.HasValue)
                    category = Repository.Instance.FindOne<Category>(c => c.Id == model.SelectedCategory.Value);
                task = new Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    Category = category,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                TaskStatus taskStatus = new TaskStatus
                {
                    ToStatus = status,
                    Comment = "",
                    CreatedAt = DateTime.UtcNow
                };
                task.AddStatus(taskStatus);
                Repository.Instance.Add(task);
                txn.Commit();
            }
            return task;
        }
    }
}
