using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class CategoryListViewModel : IEnumerable<CategoryRowViewModel>
    {
        private readonly List<CategoryRowViewModel> storage = new List<CategoryRowViewModel>();

        public CategoryListViewModel(IEnumerable<Tag> categories)
        {
            storage.AddRange(categories.Select(c => new CategoryRowViewModel(c)));
        }

        public string PageTitle
        {
            get { return "Categories"; }
        }

        public IEnumerator<CategoryRowViewModel> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}