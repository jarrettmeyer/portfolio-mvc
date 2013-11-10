using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Actions;
using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Actions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        private readonly ActionResolver actionResolver;        

        public TasksController(ActionResolver actionResolver)
        {
            this.actionResolver = actionResolver;            
        }

        [HttpGet]
        public ActionResult Index()
        {
            var action = actionResolver.GetAction<GetTasksIndexView>();
            action.OnSuccess = () => View("Index", action.ViewModel);
            return new ActionResultWrapper(action);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var action = actionResolver
                .GetAction<GetTaskShowView>()
                .ForId(id);
            action.OnSuccess = () => View("Show", action.ViewModel);
            return new ActionResultWrapper(action);
        }

        [HttpGet]
        public ActionResult New()
        {
            var action = actionResolver.GetAction<GetNewTaskView>();
            action.OnSuccess = () => View("New", action.Form);
            return new ActionResultWrapper(action);
        }

        [HttpPost]
        public ActionResult New(TaskInputModel model)
        {
            var action = actionResolver
                .GetAction<PostNewTaskForm>()
                .WithForm(model)
                .WithTempData(TempData);
            return new ActionResultWrapper(action);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var action = actionResolver.GetAction<GetEditTaskView>()
                .ForId(id);
            action.OnSuccess = () => View("Edit", action.Form);
            return new ActionResultWrapper(action);
        }

        [HttpPost]
        public ActionResult Edit(TaskInputModel model)
        {
            var action = actionResolver.GetAction<PostEditTaskForm>()
                .WithForm(model);
            action.OnSuccess = () => RedirectToAction("Show", new { id = action.Id });
            action.OnError = () => View("Edit", model);
            return new ActionResultWrapper(action);            
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var action = actionResolver
                .GetAction<DeleteTask>()
                .ForId(id);            
            return new ActionResultWrapper(action);
        }
    }
}
