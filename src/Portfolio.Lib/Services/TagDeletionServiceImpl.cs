using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TagDeletionServiceImpl : ITagDeletionService
    {
        private Tag tag;
        private readonly IRepository repository;

        public TagDeletionServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag DeleteTag(int id)
        {
            using (var transaction = repository.BeginTransaction())
            {
                tag = repository.Load<Tag>(id);
                tag.IsActive = false;
                tag.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return tag;
            }            
        }
    }
}