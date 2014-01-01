using System;
using System.Diagnostics.Contracts;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand, Tag>
    {
        private readonly ISession session;
        private Tag tag;

        public UpdateTagCommandHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Tag Handle(UpdateTagCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                UpdateTagProperties(command);
                transaction.Commit();
                return tag;
            }
        }

        private void UpdateTagProperties(UpdateTagCommand command)
        {
            tag = session.Load<Tag>(command.Id);
            tag.Slug = command.Slug;
            tag.Description = command.Description.Trim();
            tag.UpdatedAt = Clock.Instance.Now;            
        }
    }
}