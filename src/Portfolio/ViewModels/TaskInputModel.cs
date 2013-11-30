using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TaskInputModel
    {
        public TaskInputModel()
        {
            Tags = new List<TagViewModel>();
        }

        public TaskInputModel(Task task)
        {
            Ensure.ArgumentIsNotNull(task, "task");

            Tags = task.Tags.Select(tag => new TagViewModel(tag.Id, tag.Slug, tag.Description)).ToList();
            Description = task.Description;
            DueOn = task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "";
            Id = task.Id;
            Title = task.Title;
        }

        public string ActionName
        {
            get { return IsNew ? "New" : "Edit"; }
        }

        public string ControllerName
        {
            get { return "Tasks"; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string DueOn { get; set; }

        public int Id { get; set; }

        public bool IsNew
        {
            get { return Id == 0; }
        }

        public string PageTitle
        {
            get { return Id == 0 ? "New Task" : "Edit Task"; }
        }

        public object RouteValues
        {
            get
            {
                if (IsNew)
                    return new { };

                return new { id = Id };
            }
        }

        public IList<TagViewModel> Tags { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        [StringLength(256)]
        public string Title { get; set; }
    }
}