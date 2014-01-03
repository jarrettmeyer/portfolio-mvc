using System.Diagnostics.Contracts;
using Portfolio.Lib.Models;

namespace Portfolio.API.Models
{
    public class PostTaskResult
    {
        public PostTaskResult(Task task)
        {
            Contract.Requires(task != null);

            this.Id = task.Id;
        }

        public int Id { get; set; }
    }
}