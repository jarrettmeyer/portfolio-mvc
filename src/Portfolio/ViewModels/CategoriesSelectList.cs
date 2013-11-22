using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Caching;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class CategoriesSelectList
    {
        public const string CACHE_KEY = "all_categories";
        public const string TEXT_PROPERTY = "Description";
        public const string VALUE_PROPERTY = "Id";

        public static IEnumerable<CategorySelectListModel> Categories
        {
            get
            {
                var cachedCategories = Cache.Instance.Get(CACHE_KEY);
                return (IEnumerable<CategorySelectListModel>)cachedCategories;
            }
        }

        public static void Initialize(IRepository repository = null)
        {
            if (repository == null)
                repository = ServiceLocator.Instance.GetService<IRepository>();

            var categories = repository.Find<Category>(c => c.IsActive).OrderBy(c => c.Description).ToArray();
            var models = categories.Select(c => new CategorySelectListModel(c.Id, c.Description));
            Cache.Instance.Add(CACHE_KEY, models);
        }

        public static SelectList SelectList(int? selected)
        {
            return new SelectList(Categories, VALUE_PROPERTY, TEXT_PROPERTY, selected);
        }
    }
}