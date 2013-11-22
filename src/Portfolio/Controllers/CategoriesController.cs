using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class CategoriesController : ApplicationController
    {
        private readonly IRepository repository;

        public CategoriesController()
        {
            repository = ServiceLocator.Instance.GetService<IRepository>();
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            ICategoryDeletionService service = ServiceLocator.Instance.GetService<ICategoryDeletionService>();
            Category category = service.DeleteCategory(id);
            FlashMessages.AddSuccessMessage(string.Format("Deleted category: {0}", category.Description));

            // This will be called with JavaScript, so we don't have an actual result to return.
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.FindOne<Category>(c => c.Id == id);
            var model = new CategoryInputModel(category);            
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryInputModel model)
        {
            ICategoryUpdateService service = ServiceLocator.Instance.GetService<ICategoryUpdateService>();
            Category category = service.UpdateCategory(model);
            CategoriesSelectList.Initialize(repository);
            FlashMessages.AddSuccessMessage(string.Format("Successfully updated category: {0}", category.Description));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = repository.FindAll<Category>().OrderBy(c => c.Description).ToArray();
            var model = new CategoryListViewModel(categories);
            return View("Index", model);
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
            ICategoryCreationService service = ServiceLocator.Instance.GetService<ICategoryCreationService>();
            Category category = service.CreateCategory(model);
            CategoriesSelectList.Initialize(repository);
            FlashMessages.AddSuccessMessage(string.Format("Successfully created new category: {0}", category.Description));
            return RedirectToAction("Index");
        }
    }
}
