using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TagsQueryHandler : IQueryHandler<TagsQuery, TagCollection>
    {
        private readonly ISession session;

        public TagsQueryHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public TagCollection Handle(TagsQuery query)
        {
            var tags = session.Query<Tag>()
                .OrderBy(t => t.Description);
            return new TagCollection(tags);
        }
    }
}
