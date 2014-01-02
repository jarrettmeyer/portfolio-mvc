using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TasksByTagQuery : IQuery<TaskCollection>
    {
        public TasksByTagQuery() { }

        public TasksByTagQuery(string tagged)
        {
            this.Tagged = tagged;
        }

        public string Tagged { get; set; }
    }
}
