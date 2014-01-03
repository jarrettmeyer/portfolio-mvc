using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.API.Models
{
    public class GetTasksResult : IEnumerable<GetTaskResult>
    {
        private readonly List<GetTaskResult> tasks = new List<GetTaskResult>();

        public GetTasksResult(IEnumerable<Task> tasks)
        {
            Contract.Requires(tasks != null);
            this.tasks.AddRange(tasks.Select(t => new GetTaskResult(t)));
        }

        public IEnumerator<GetTaskResult> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}