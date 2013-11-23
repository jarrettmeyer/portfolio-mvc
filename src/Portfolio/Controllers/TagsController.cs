using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TagsController : ApplicationController
    {
        private readonly IRepository repository;

        public TagsController()
        {
            repository = ServiceLocator.Instance.GetService<IRepository>();
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            ITagDeletionService service = ServiceLocator.Instance.GetService<ITagDeletionService>();
            Tag tag = service.DeleteCategory(id);
            FlashMessages.AddSuccessMessage(string.Format("Deleted Tag: {0}", tag.Description));

            // This will be called with JavaScript, so we don't have an actual result to return.
            return Json(new { success = true });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.FindOne<Tag>(c => c.Id == id);
            var model = new TagInputModel(category);            
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, TagInputModel model)
        {
            ITagUpdateService service = ServiceLocator.Instance.GetService<ITagUpdateService>();
            Tag tag = service.UpdateCategory(model);
            CategorySelectList.Initialize(repository);
            FlashMessages.AddSuccessMessage(string.Format("Successfully updated Tag: {0}", tag.Description));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = repository.FindAll<Tag>().OrderBy(c => c.Description).ToArray();
            var model = new TagListViewModel(categories);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new TagInputModel();
            return View("New", model);
        }

        [HttpPost]
        public ActionResult New(TagInputModel model)
        {
            try
            {
                ITagCreationService service = ServiceLocator.Instance.GetService<ITagCreationService>();
                Tag tag = service.CreateCategory(model);
                CategorySelectList.Initialize(repository);
                FlashMessages.AddSuccessMessage(string.Format("Successfully created new Tag: {0}", tag.Description));
                return RedirectToAction("Index");
            }
            catch (UniqueRecordViolationException ex)
            {
                FlashMessages.AddErrorMessage(ex.Message);
                return View("New", model);                
            }            
        }
    }
}
