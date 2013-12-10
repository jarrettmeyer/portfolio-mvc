using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

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
                task.Complete();
                task.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return task;
            }            
        }
    }
}