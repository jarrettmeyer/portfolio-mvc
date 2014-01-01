using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Caching;
using Portfolio.Lib.Models;

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