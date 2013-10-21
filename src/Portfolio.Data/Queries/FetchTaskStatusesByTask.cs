using System.Collections.Generic;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public abstract class FetchTaskStatusesByTask : AbstractQuery<IEnumerable<TaskStatus>>
    {
    }
}
