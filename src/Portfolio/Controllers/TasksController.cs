using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        public TasksController()
        {
            if (!TagSelectList.IsInitialized)
                TagSelectList.Initialize();
        }

        [HttpPost]
        public ActionResult Complete(int id)
        {
            ITaskCompletionService service = ServiceLocator.Instance.GetService<ITaskCompletionService>();
            Task task = service.CompleteTask(id);
            FlashMessages.AddSuccessMessage(string.Format("Completed task: {0}", task.Title));
            return Json(new { success = true });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            IRepository repository = ServiceLocator.Instance.GetService<IRepository>();
            using (var transaction = repository.BeginTransaction())
            {
                Task task = repository.Load<Task>(id);
                repository.Delete(task);
                transaction.Commit();
                return new EmptyResult();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var repository = ServiceLocator.Instance.GetService<IRepository>();
            var task = repository.Load<Task>(id);
            var model = new TaskInputModel(task);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(TaskInputModel model)
        {
            CheckModelState(() => OnInvalidTaskForm("Edit", model));
            var service = ServiceLocator.Instance.GetService<ITaskUpdateService>();
            var task = service.UpdateTask(model);
            FlashMessages.AddSuccessMessage(string.Format("Updated task: {0}", task.Title));
            return RedirectToAction("Show", new { id = model.Id });            
        }

        [HttpGet]
        public ActionResult Index()
        {
            var repository = ServiceLocator.Instance.GetService<IRepository>();
            var tasks = repository.Find<Task>(t => !t.IsCompleted)
                .OrderBy(t => t.DueOn).ThenBy(t => t.Id);
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
        public ActionResult New(TaskInputModel model)
        {
            CheckModelState(() => OnInvalidTaskForm("New", model));
            ITaskCreationService service = ServiceLocator.Instance.GetService<ITaskCreationService>();
            Task task = service.CreateTask(model);
            FlashMessages.AddSuccessMessage(string.Format("Created new task: {0}", task.Title));
            return RedirectToAction("Show", new { id = task.Id });            
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            IRepository repository = ServiceLocator.Instance.GetService<IRepository>();
            var task = repository.Load<Task>(id);
            var model = new TaskViewModel(task);
            return View("Show", model);
        }

        private ActionResult OnInvalidTaskForm(string viewName, TaskInputModel model)
        {
            FlashMessages.AddErrorMessage(DEFAULT_FORM_ERROR_MESSAGE);
            return View("New", model);
        }
    }
}
