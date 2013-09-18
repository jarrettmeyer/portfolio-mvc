using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain
{
    public class CategoryMapper
    {
        public static CategoryViewModel Map(Category category)
        {
            var categoryViewModel = new CategoryViewModel();

            if (category != null)
            {
                categoryViewModel.Description = category.Description;
                categoryViewModel.Id = category.Id;
            }
            return categoryViewModel;
        }
    }
}
