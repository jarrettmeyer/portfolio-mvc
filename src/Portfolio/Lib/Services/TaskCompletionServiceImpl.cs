using Portfolio.Lib.Data;
using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public class TaskCompletionServiceImpl : ITaskCompletionService
    {
        private readonly IRepository repository;
        private Task task;

        public TaskCompletionServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public virtual Task CompleteTask(int id)
        {
            using (var transaction = repository.BeginTransaction())
            {
                task = repository.Load<Task>(id);
                task.IsCompleted = true;
                task.CompletedAt = Clock.Instance.Now;
                task.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return task;
            }            
        }
    }
}