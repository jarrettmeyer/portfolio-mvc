using System;
using System.Diagnostics.Contracts;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class ActiveTagsQueryHandler : IQueryHandler<ActiveTagsQuery, TagCollection>
    {
        private readonly ISession session;

        public ActiveTagsQueryHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public TagCollection Handle(ActiveTagsQuery query)
        {
            var tags = session.Query<Tag>()
                .Where(t => t.IsActive == query.IsActive);
            return new TagCollection(tags);
        }
    }
}
