using System.Linq;
using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Lib;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.Services;
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            return new DeleteResponder(this)
                .RespondWith<ITagDeletionService>(x => x.DeleteTag(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tag = repository.FindOne<Tag>(c => c.Id == id);
            var model = new TagInputModel(tag);            
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, TagInputModel model)
        {
            ITagUpdateService service = ServiceLocator.Instance.GetService<ITagUpdateService>();
            service.UpdateTag(model.ToTag());
            TagSelectList.Initialize(repository);
            this.Flash("success", string.Format("Successfully updated Tag: {0}", model.Description));
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
                service.CreateTag(model.ToTag());
                TagSelectList.Initialize(repository);
                this.Flash("success", string.Format("Successfully created new Tag: {0}", model.Description));
                return RedirectToAction("Index");
            }
            catch (UniqueRecordViolationException ex)
            {
                this.Flash("danger", ex.Message);
                return View("New", model);                
            }            
        }
    }
}
