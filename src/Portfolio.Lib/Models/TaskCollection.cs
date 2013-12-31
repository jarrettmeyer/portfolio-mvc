using System.Collections;
using System.Collections.Generic;

namespace Portfolio.Lib.Models
{
    public class TaskCollection : IEnumerable<Task>
    {
        readonly IEnumerable<Task> storage;

        public TaskCollection(IEnumerable<Task> tasks)
        {
            this.storage = tasks ?? new List<Task>();
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
