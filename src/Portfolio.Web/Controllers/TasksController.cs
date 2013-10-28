using System.Web.Mvc;
using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Actions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
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
        public ActionResult Edit(TaskInputModel model)
        {
            //TaskViewModel result = taskService.UpdateTask(model);
            //return Json(result);
            return null;
        }

        [HttpPost]
        public ActionResult New(TaskInputModel model)
        {
            var action = actionResolver
                .GetAction<PostNewTaskForm>()
                .WithForm(model);
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
