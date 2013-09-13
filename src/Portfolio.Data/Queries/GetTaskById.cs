using System;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public abstract class GetTaskById : AbstractQuery<Task>
    {
        public Guid Id { get; set; }
    }
}
