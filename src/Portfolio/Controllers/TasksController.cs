using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repository = ServiceLocator.Instance.GetService<IRepository>();
            var tasks = repository.FindAll<Task>().OrderBy(t => t.Id);
            var model = new TaskListViewModel(tasks);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            IRepository repository = ServiceLocator.Instance.GetService<IRepository>();
            var task = repository.Load<Task>(id);
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
                FlashMessages.AddErrorMessage(DEFAULT_FORM_ERROR_MESSAGE);
                return View("New", model);
            });
            ITaskCreationService service = ServiceLocator.Instance.GetService<ITaskCreationService>();
            Task task = service.CreateTask(model);
            FlashMessages.AddSuccessMessage(string.Format("Created new task: {0}", task.Title));
            return RedirectToAction("Show", new { id = task.Id });            
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
            CheckModelState(() =>
            {
                FlashMessages.AddErrorMessage(DEFAULT_FORM_ERROR_MESSAGE);
                return View("Edit", model);
            });
            var repository = ServiceLocator.Instance.GetService<IRepository>();
            using (var transaction = repository.BeginTransaction())
            {
                Task task = repository.Load<Task>(model.Id);
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
            IRepository repository = ServiceLocator.Instance.GetService<IRepository>();
            using (var transaction = repository.BeginTransaction())
            {
                Task task = repository.Load<Task>(id);
                repository.Delete(task);
                transaction.Commit();
                return new EmptyResult();
            }
        }
    }
}
