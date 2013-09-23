using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Data;
using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services.Impl
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryServiceImpl(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public CategoryViewModel CreateNewCategory(CategoryInputModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var category = new Category
                           {
                               Description = model.Description,
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           };
            repository.Add(category);
            CategoryViewModel result = CategoryMapper.Map(category);
            return result;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var categoryViewModels = repository.All<Category>()
                .OrderBy(c => c.Description)
                .Select(CategoryMapper.Map)
                .ToArray();
            return categoryViewModels;
        }
    }
}
