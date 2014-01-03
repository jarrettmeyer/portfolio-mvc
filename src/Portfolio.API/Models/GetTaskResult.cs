using System.Diagnostics.Contracts;
using Portfolio.Lib;
using Portfolio.Lib.Models;

namespace Portfolio.API.Models
{
    public class GetTaskResult
    {
        public GetTaskResult(Task task)
        {
            Contract.Requires(task != null);

            this.Description = task.Description;
            this.DueOn = task.DueOn.ToEpoch();
            this.Id = task.Id;
            this.Tags = new GetTagsResult(task.Tags);
            this.Title = task.Title;
        }

        public string Description { get; set; }

        public long? DueOn { get; set; }

        public int Id { get; set; }

        public GetTagsResult Tags { get; set; }

        public string Title { get; set; }
    }
}