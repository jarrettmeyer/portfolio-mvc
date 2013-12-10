using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.ViewModels
{
    public class TaskListViewModel : IEnumerable<TaskRowViewModel>
    {
        private readonly List<TaskRowViewModel> storage = new List<TaskRowViewModel>();

        public TaskListViewModel(IEnumerable<Task> tasks)
        {
            storage.AddRange(tasks.Select(t => new TaskRowViewModel(t)));
        }

        public IEnumerator<TaskRowViewModel> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}