using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Lib;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;
using Portfolio.Lib.Services;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class TagsController : ApplicationController
    {
        readonly IMediator mediator;
        private readonly IRepository repository;

        public TagsController(IMediator mediator)
        {
            Contract.Requires<ArgumentNullException>(mediator != null);
            this.mediator = mediator;
            repository = ServiceLocator.Instance.GetService<IRepository>();
        }
        
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteTagCommand command)
        {
            return new DeleteResponder(this)
                .RespondWith(mediator, command, afterCommandSent: UpdateTagSelectList);
        }

        [HttpGet]
        public ActionResult Edit(TagByIdQuery query)
        {
            var tag = mediator.Request(query);
            var model = new TagInputModel(tag);            
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(TagInputModel model)
        {
            ITagUpdateService service = ServiceLocator.Instance.GetService<ITagUpdateService>();
            service.UpdateTag(model.ToTagDTO());
            UpdateTagSelectList();
            this.Flash("success", string.Format("Successfully updated Tag: {0}", model.Description));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            TagCollection tags = mediator.Request(new TagsQuery());
            var model = new TagListViewModel(tags);
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
                mediator.Send(model.ToCreateTagCommand());
                UpdateTagSelectList();
                this.Flash("success", string.Format("Successfully created new Tag: {0}", model.Description));
                return RedirectToAction("Index");
            }
            catch (UniqueRecordViolationException ex)
            {
                this.Flash("danger", ex.Message);
                return View("New", model);                
            }            
        }

        private void UpdateTagSelectList()
        {
            var tags = mediator.Request(new ActiveTagsQuery());
            TagSelectList.Initialize(tags);
        }
    }
}
