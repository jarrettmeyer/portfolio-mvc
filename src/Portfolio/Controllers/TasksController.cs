using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Actions;
using Portfolio.ViewModels;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Controllers
{
    public class TasksController : ApplicationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var action = ActionResolver.GetAction<GetTasksIndexView>();
            action.OnSuccess = () => View("Index", action.ViewModel);
            return new ActionResultWrapper(action);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var action = ActionResolver
                .GetAction<GetTaskShowView>()
                .ForId(id);
            action.OnSuccess = () => View("Show", action.ViewModel);
            return new ActionResultWrapper(action);
        }

        [HttpGet]
        public ActionResult New()
        {
            var action = ActionResolver.GetAction<GetNewTaskView>();
            action.OnSuccess = () => View("New", action.Form);
            return new ActionResultWrapper(action);
        }

        [HttpPost]
        public ActionResult New(TaskInputModel model)
        {
            var action = ActionResolver
                .GetAction<PostNewTaskForm>()
                .WithForm(model)
                .WithTempData(TempData);
            action.OnError = () => View("New", model);
            return new ActionResultWrapper(action);
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
    }
}
