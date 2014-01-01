using System;
using System.Collections.Generic;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CreateTaskCommand : ICommand<Task>
    {
        private IEnumerable<int> tags;

        public string Description { get; set; }

        public DateTime? DueOn { get; set; }

        public IEnumerable<int> TagIds
        {
            get { return tags ?? new int[] { }; }
            set { tags = value; }
        }

        public string Title { get; set; }
    }
}
