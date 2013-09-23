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
            IEnumerable<CategoryViewModel> result = categoryService.GetAllCategories();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult New(CategoryInputModel model)
        {
            CategoryViewModel result = categoryService.CreateNewCategory(model);
            return Json(result);
        }
    }
}
