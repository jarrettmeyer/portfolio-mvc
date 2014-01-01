using System;
using System.Collections.Generic;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class UpdateTaskCommand : ICommand<Task>
    {
        private IEnumerable<int> tagIds;

        public string Description { get; set; }

        public DateTime? DueOn { get; set; }

        public int Id { get; set; }

        public IEnumerable<int> TagIds
        {
            get { return tagIds ?? new int[] { }; }
            set { tagIds = value; }
        }

        public string Title { get; set; }
    }
}
