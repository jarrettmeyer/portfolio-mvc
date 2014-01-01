using System;
using System.Diagnostics.Contracts;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TagByIdQueryHandler : IQueryHandler<TagByIdQuery, Tag>
    {
        private readonly ISession session;

        public TagByIdQueryHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Tag Handle(TagByIdQuery query)
        {
            int id = query.Id;
            Tag tag = session.Load<Tag>(id);
            return tag;
        }
    }
}
