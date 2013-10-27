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
            return actionResolver.GetAction<GetTasksIndexView>();            
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            return actionResolver
                .GetAction<GetTaskShowView>()
                .ForId(id);
        }

        [HttpGet]
        public ActionResult New()
        {
            return actionResolver.GetAction<GetNewTaskView>();
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
            return actionResolver
                .GetAction<PostNewTaskForm>()
                .WithForm(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return actionResolver
                .GetAction<DeleteTask>()
                .ForId(id);            
        }
    }
}
