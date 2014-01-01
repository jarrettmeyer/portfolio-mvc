using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TaskByIdQuery : IQuery<Task>
    {
        public TaskByIdQuery() { }

        public TaskByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
