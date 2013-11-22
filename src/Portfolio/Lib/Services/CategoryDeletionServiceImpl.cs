using System;
using Portfolio.Lib.Data;
using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public class CategoryDeletionServiceImpl : ICategoryDeletionService
    {
        private Category category;
        private readonly IRepository repository;

        public CategoryDeletionServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Category DeleteCategory(int id)
        {
            using (var transaction = repository.BeginTransaction())
            {
                category = repository.Load<Category>(id);
                category.IsActive = false;
                category.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
                return category;
            }            
        }
    }
}