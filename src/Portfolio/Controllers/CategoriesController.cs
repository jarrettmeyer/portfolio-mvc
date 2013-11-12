using System;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class CategoriesController : Controller
    {
       [HttpGet]
        public ActionResult Index()
        {
            var categories = Repository.Instance.FindAll<Category>().OrderBy(c => c.Description).ToArray();
            return View("Index", categories);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new CategoryInputModel();
            return View("New", model);
        }

        [HttpPost]
        public ActionResult New(CategoryInputModel model)
        {
            var category = new Category
            {
                Description = model.Description.Trim(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            Repository.Instance.Add(category);
            return RedirectToAction("Index");
        }
    }
}
