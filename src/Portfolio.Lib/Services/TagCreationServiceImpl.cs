using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TagCreationServiceImpl : ITagCreationService
    {
        private readonly IRepository repository;
        private Tag tag;
        private ITransactionAdapter transaction;

        public TagCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;            
        }

        public virtual void CreateTag(Tag tag)
        {
            this.tag = tag;
            using (transaction = repository.BeginTransaction())
            {
                SetTagProperties();
                PersistNewTag();
            }
        }

        private void PersistNewTag()
        {
            repository.Add(tag);
            transaction.Commit();
        }

        private void SetTagProperties()
        {
            tag.IsActive = true;
            tag.CreatedAt = Clock.Instance.Now;
            tag.UpdatedAt = Clock.Instance.Now;
        }
    }
}