using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain
{
    public class TaskMapper
    {
        public static TaskViewModel Map(Task task)
        {
            var taskViewModel = new TaskViewModel();
            if (task != null)
            {
                taskViewModel.Category = CategoryMapper.Map(task.Category);
                taskViewModel.CreatedAt = task.CreatedAt;
                taskViewModel.Description = task.Description;
                taskViewModel.DueOn = task.DueOn;
                taskViewModel.Id = task.Id;
                taskViewModel.IsCompleted = task.IsCompleted;
                taskViewModel.Status = StatusMapper.Map(task.CurrentStatus);
                taskViewModel.UpdatedAt = task.UpdatedAt;
            }
            return taskViewModel;            
        }
    }
}
