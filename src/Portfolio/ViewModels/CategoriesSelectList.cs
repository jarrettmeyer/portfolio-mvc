using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Caching;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio.ViewModels
{
    public class CategoriesSelectList
    {
        public static IEnumerable<CategorySelectListModel> Categories
        {
            get
            {
                var cachedCategories = Cache.Instance.Get("all_categories");
                return (IEnumerable<CategorySelectListModel>)cachedCategories;
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

        public static void Initialize()
        {
            if (!IsInitialized)
                Categories = Repository.Instance
                    .FindAll<Category>()
                    .Select(x => new CategorySelectListModel(x.Id, x.Description));
        }

        public static SelectList SelectList(int? selected)
        {
            return new SelectList(Categories, "Id", "Description", selected);
        }
    }
}