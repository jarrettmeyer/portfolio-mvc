using System;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class CategoryCreationServiceImpl : ICategoryCreationService
    {
        private readonly Category category;
        private readonly IRepository repository;

        public CategoryCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;
            this.category = new Category();
        }

        public virtual Category CreateCategory(CategoryInputModel categoryInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                SetCategoryProperties(categoryInputModel);
                PersistNewCategory(transaction);
                return category;
            }
            
        }

        private void PersistNewCategory(ITransactionAdapter transaction)
        {
            repository.Add(category);
            transaction.Commit();
        }

        private void SetCategoryProperties(CategoryInputModel categoryInputModel)
        {
            category.Description = categoryInputModel.Description.Trim();
            category.IsActive = true;
            category.CreatedAt = DateTime.UtcNow;
            category.UpdatedAt = DateTime.UtcNow;
        }
    }
}