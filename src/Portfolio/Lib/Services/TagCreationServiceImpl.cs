using System;
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
            tag.Description = tagInputModel.Description.Trim();
            tag.Slug = tagInputModel.Slug;
            tag.IsActive = true;
            tag.CreatedAt = DateTime.UtcNow;
            tag.UpdatedAt = DateTime.UtcNow;
        }
    }
}