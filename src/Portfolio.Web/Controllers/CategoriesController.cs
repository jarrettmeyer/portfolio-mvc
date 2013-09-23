using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Portfolio.Domain.Services;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class CategoriesController : ApplicationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            if (categoryService == null)
                throw new ArgumentNullException("categoryService");

            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            
            // We are ensuring that the list of categories contains an empty
            // element at the beginning of the list.
            result.Add(new CategoryViewModel());
            result.AddRange(categoryService.GetAllCategories());

            return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult New(CategoryInputModel model)
        {
            CategoryViewModel result = categoryService.CreateNewCategory(model);
            return Json(result);
        }
    }
}
