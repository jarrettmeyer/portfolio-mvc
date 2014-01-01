using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.ViewModels
{
    public class TagListViewModel : IEnumerable<TagRowViewModel>
    {
        private readonly List<TagRowViewModel> storage = new List<TagRowViewModel>();

        public TagListViewModel(IEnumerable<Tag> categories)
        {
            Contract.Requires(categories != null);
            storage.AddRange(categories.Select(c => new TagRowViewModel(c)));
        }

        public string PageTitle
        {
            get { return "Tags"; }
        }

        public IEnumerator<TagRowViewModel> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}