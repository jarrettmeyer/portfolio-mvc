using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class FetchAllCategoriesImpl : FetchAllCategories
    {
        private readonly ISession session;

        public FetchAllCategoriesImpl(ISession session)
        {
            this.session = session;
        }

        public override IEnumerable<Category> ExecuteQuery()
        {
            var categories = session.Query<Category>()                
                .OrderBy(c => c.Description)
                .ToArray();
            return categories;
        }
    }
}