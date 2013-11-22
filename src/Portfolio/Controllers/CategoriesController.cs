using System;
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
            var category = repository.Load<Category>(id);
            category.IsActive = false;
            repository.SaveChanges();
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.FindOne<Category>(c => c.Id == id);
            var model = new CategoryInputModel
            {
                Description = category.Description,
                Id = category.Id
            };
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryInputModel model)
        {
            Category category;
            using (var transaction = repository.BeginTransaction())
            {
                category = repository.FindOne<Category>(c => c.Id == id);
                category.Description = model.Description.Trim();
                category.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
            }
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
            Category category;
            using (var txn = repository.BeginTransaction())
            {
                category = new Category
                {
                    Description = model.Description.Trim(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                repository.Add(category);
                txn.Commit();
            }
            CategoriesSelectList.Initialize(repository);
            FlashMessages.AddSuccessMessage(string.Format("Successfully created new category: {0}", category.Description));
            return RedirectToAction("Index");
        }
    }
}
