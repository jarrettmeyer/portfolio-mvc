using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand, Tag>
    {
        private readonly IRepository repository;
        private Tag tag;

        public UpdateTagCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag Handle(UpdateTagCommand command)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTagProperties(command);
                transaction.Commit();
                return tag;
            }
        }

        private void UpdateTagProperties(UpdateTagCommand command)
        {
            tag = repository.Load<Tag>(command.Id);
            tag.Slug = command.Slug;
            tag.Description = command.Description.Trim();
            tag.UpdatedAt = Clock.Instance.Now;            
        }
    }
}