using System;
using System.Web.Mvc;
using Portfolio.Domain.Services;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class TasksController : ApplicationController
    {        
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            if (taskService == null)
                throw new ArgumentNullException("taskService");

            this.taskService = taskService;
        }

        public ActionResult Index()
        {
            var tasks = taskService.GetAllTasks();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(TaskInputModel model)
        {
            TaskViewModel result = taskService.UpdateTask(model);
            return Json(result);
        }

        [HttpPost]
        public ActionResult New(TaskInputModel model)
        {
            TaskViewModel result = taskService.CreateNewTask(model);
            return Json(result);
        }
    }
}
