using Portfolio.Lib.Data;
using Portfolio.Web.Models;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetEditTaskView : AbstractAction
    {
        private int id;
        private readonly IRepository repository;
        private Task task;
        private TaskInputModel taskInputModel;

        public GetEditTaskView(IRepository repository)
        {
            this.repository = repository;            
        }

        public TaskInputModel Form
        {
            get { return taskInputModel; }
        }

        public override void Execute()
        {
            task = repository.Load<Task>(id);
            taskInputModel = new TaskInputModel(task);
            
            CategoriesSelectList.Initialize(repository);
        }

        public GetEditTaskView ForId(int id)
        {
            this.id = id;
            return this;
        }
    }
}