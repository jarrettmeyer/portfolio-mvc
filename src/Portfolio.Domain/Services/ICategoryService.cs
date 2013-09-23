using System.Collections.Generic;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services
{
    public interface ICategoryService
    {
        CategoryViewModel CreateNewCategory(CategoryInputModel categoryInputModel);

        IEnumerable<CategoryViewModel> GetAllCategories();
    }
}
