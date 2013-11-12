using System.Collections.Generic;
using Portfolio.Models;
using Portfolio.Web.Lib.Queries;

namespace Portfolio.Lib.Queries
{
    public abstract class FetchTaskStatusesByTask : AbstractQuery<IEnumerable<TaskStatus>>
    {
    }
}
