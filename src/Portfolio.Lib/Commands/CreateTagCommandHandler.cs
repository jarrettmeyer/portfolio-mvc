using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, Tag>
    {
        readonly ISession session;
        Tag tag;
        ITransaction transaction;

        public CreateTagCommandHandler(ISession session)
        {
            this.session = session;
        }

        public Tag Handle(CreateTagCommand command)
        {
            using (transaction = session.BeginTransaction())
            {
                tag = new Tag();
                SetTagProperties(command);
                PersistNewTag();
                return tag;
            }
        }

        private void PersistNewTag()
        {
            session.Save(tag);            
            transaction.Commit();
        }

        private void SetTagProperties(CreateTagCommand command)
        {
            tag.Slug = command.Slug;
            tag.Description = command.Description;
            tag.IsActive = true;
            tag.CreatedAt = Clock.Instance.Now;
            tag.UpdatedAt = Clock.Instance.Now;
        }
    }
}
