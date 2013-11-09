using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Common.Caching;
using Portfolio.Data;
using Portfolio.Data.Models;

namespace Portfolio.Web.ViewModels
{
    public class CategoriesSelectList
    {
        public static IEnumerable<SelectListItem> Categories
        {
            get
            {
                var cachedCategories = Cache.Instance.Get("all_categories");
                return (IEnumerable<SelectListItem>)cachedCategories;
            }
            set 
            {
                if (value == null)
                    throw new NullReferenceException("Unable to assign null category collection to cache.");

                Cache.Instance.Add("all_categories", value);
                IsInitialized = true;
            }
        }

        public static bool IsInitialized { get; private set; }

        public static void Initialize(IRepository repository)
        {
            if (!IsInitialized)
                Categories = repository
                    .FindAll<Category>()
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Description });
        }

        public static SelectList SelectList(int? selected)
        {
            return new SelectList(Categories, "Value", "Text", selected);
        }

        public class CategorySelectListModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }
}