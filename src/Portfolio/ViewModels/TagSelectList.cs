using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Caching;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.Services;

namespace Portfolio.ViewModels
{
    public static class TagSelectList
    {
        public const string CACHE_KEY = "active_tags";
        public const string TEXT_PROPERTY = "Text";
        public const string VALUE_PROPERTY = "Value";

        public static bool IsInitialized { get; private set; }

        public static IEnumerable<SelectListItem> Tags
        {
            get
            {
                var cachedTags = Cache.Instance.Get(CACHE_KEY);
                return (IEnumerable<SelectListItem>)cachedTags;
            }
        }

        public static void Initialize(IRepository repository = null)
        {
            if (repository == null)
                repository = ServiceLocator.Instance.GetService<IRepository>();

            var tags = repository.Find<Tag>(c => c.IsActive).OrderBy(c => c.Description).ToArray();
            Initialize(tags);
        }

        public static void Initialize(IEnumerable<Tag> tags)
        {
            var models = tags.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Description });
            Cache.Instance.Add(CACHE_KEY, models);
            IsInitialized = true;
        }

        public static SelectList SelectList(int? selected = null)
        {
            return new SelectList(Tags, VALUE_PROPERTY, TEXT_PROPERTY, selected);
        }
    }
}