using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TaskDeletionServiceImpl : ITaskDeletionService
    {
        private readonly IRepository repository;
        private Task task;

        public TaskDeletionServiceImpl(IRepository repository)
        {
            Ensure.ArgumentIsNotNull(repository, "repository");
            this.repository = repository;
        }

        public Task DeleteTask(int id)
        {            
            using (var transaction = repository.BeginTransaction())
            {
                task = repository.Load<Task>(id);
                repository.Delete(task);
                transaction.Commit();
                return task;                
            }
        }
    }
}