using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TaskByIdQuery : IQuery<Task>
    {
        public int Id { get; set; }
    }
}
