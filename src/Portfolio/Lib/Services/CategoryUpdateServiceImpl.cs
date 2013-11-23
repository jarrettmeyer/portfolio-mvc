using System;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class CategoryUpdateServiceImpl : ICategoryUpdateService
    {
        private Tag tag;
        private readonly IRepository repository;

        public CategoryUpdateServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag UpdateCategory(CategoryInputModel categoryInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                tag = repository.Load<Tag>(categoryInputModel.Id);
                tag.Description = categoryInputModel.Description.Trim();
                tag.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
                return tag;
            }            
        }
    }
}