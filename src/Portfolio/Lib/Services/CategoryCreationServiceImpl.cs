using System;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class CategoryCreationServiceImpl : ICategoryCreationService
    {
        private readonly Tag tag;
        private readonly IRepository repository;

        public CategoryCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;
            this.tag = new Tag();
        }

        public virtual Tag CreateCategory(CategoryInputModel categoryInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                SetCategoryProperties(categoryInputModel);
                PersistNewCategory(transaction);
                return tag;
            }
            
        }

        private void PersistNewCategory(ITransactionAdapter transaction)
        {
            repository.Add(tag);
            transaction.Commit();
        }

        private void SetCategoryProperties(CategoryInputModel categoryInputModel)
        {
            tag.Description = categoryInputModel.Description.Trim();
            tag.IsActive = true;
            tag.CreatedAt = DateTime.UtcNow;
            tag.UpdatedAt = DateTime.UtcNow;
        }
    }
}