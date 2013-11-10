using System.Collections.Generic;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Queries
{
    public abstract class FetchTaskStatusesByTask : AbstractQuery<IEnumerable<TaskStatus>>
    {
    }
}
