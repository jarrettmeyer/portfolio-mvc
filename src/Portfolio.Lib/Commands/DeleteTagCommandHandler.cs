using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand, Tag>
    {
        private Tag tag;
        private readonly ISession session;

        public DeleteTagCommandHandler(ISession session)
        {
            this.session = session;
        }

        public Tag Handle(DeleteTagCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                int id = command.Id;
                tag = session.Load<Tag>(id);
                tag.IsActive = false;
                tag.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return tag;
            }            
        }
    }
}