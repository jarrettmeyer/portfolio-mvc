using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class TagCreationServiceImpl : ITagCreationService
    {
        private readonly Tag tag;
        private readonly IRepository repository;

        public TagCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;
            this.tag = new Tag();
        }

        public virtual Tag CreateCategory(TagInputModel tagInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                SetCategoryProperties(tagInputModel);
                PersistNewCategory(transaction);
                return tag;
            }
            
        }

        private void PersistNewCategory(ITransactionAdapter transaction)
        {
            repository.Add(tag);
            transaction.Commit();
        }

        private void SetCategoryProperties(TagInputModel tagInputModel)
        {
            tag.Slug = tagInputModel.Slug;
            tag.Description = tagInputModel.Description.Trim();
            tag.IsActive = true;
            tag.CreatedAt = Clock.Instance.Now;
            tag.UpdatedAt = Clock.Instance.Now;
        }
    }
}