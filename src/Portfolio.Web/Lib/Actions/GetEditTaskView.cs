using System.Collections.Generic;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetEditTaskView : AbstractAction
    {
        private IEnumerable<Category> categories;
        private int categoryId;
        private readonly FetchAllCategories fetchAllCategories;
        private readonly FetchTaskById fetchTaskById;
        private int id;
        private Task task;
        private TaskInputModel taskInputModel;

        public GetEditTaskView(FetchTaskById fetchTaskById, FetchAllCategories fetchAllCategories)
        {
            this.fetchTaskById = fetchTaskById;
            this.fetchAllCategories = fetchAllCategories;
        }

        public TaskInputModel Form
        {
            get { return taskInputModel; }
        }

        public override void Execute()
        {
            task = fetchTaskById.ExecuteQuery(id);
            categories = fetchAllCategories.ExecuteQuery();

            if (task.Category != null)
                categoryId = task.Category.Id;

            taskInputModel = new TaskInputModel(task);
            taskInputModel.Categories = categories.ToSelectList(c => c.Id, c => c.Description, categoryId);
        }

        public GetEditTaskView ForId(int id)
        {
            this.id = id;
            return this;
        }
    }
}