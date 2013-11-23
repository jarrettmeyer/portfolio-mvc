using System;
using Portfolio.Lib.Data;
using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public class CategoryDeletionServiceImpl : ICategoryDeletionService
    {
        private Tag tag;
        private readonly IRepository repository;

        public CategoryDeletionServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag DeleteCategory(int id)
        {
            using (var transaction = repository.BeginTransaction())
            {
                tag = repository.Load<Tag>(id);
                tag.IsActive = false;
                tag.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
                return tag;
            }            
        }
    }
}