﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TagListViewModel : IEnumerable<TagRowViewModel>
    {
        private readonly List<TagRowViewModel> storage = new List<TagRowViewModel>();

        public TagListViewModel(IEnumerable<Tag> categories)
        {
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