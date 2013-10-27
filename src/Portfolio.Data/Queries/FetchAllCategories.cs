using System.Collections.Generic;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public abstract class FetchAllCategories : AbstractQuery<IEnumerable<Category>>
    {
    }
}
