using System;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class CategoryUpdateServiceImpl : ICategoryUpdateService
    {
        private Category category;
        private readonly IRepository repository;

        public CategoryUpdateServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Category UpdateCategory(CategoryInputModel categoryInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                category = repository.Load<Category>(categoryInputModel.Id);
                category.Description = categoryInputModel.Description.Trim();
                category.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
                return category;
            }            
        }
    }
}