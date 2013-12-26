using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Portfolio.Lib;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.ViewModels
{
    public class TaskInputModel
    {
        private readonly Task task;

        public TaskInputModel()
            : this(new Task())
        {            
        }

        public TaskInputModel(Task task)
        {
            Ensure.ArgumentIsNotNull(task, "task");
            this.task = task;

            Tags = task.Tags.Select(tag => new TagViewModel(tag.Id, tag.Slug, tag.Description)).ToList();
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
        public string Description
        {
            get { return task.Description; }
            set
            {
                if (value == null)
                    return;

                task.Description = value.Trim();
            }
        }

        public string DueOn
        {
            get { return task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : ""; }
            set { task.DueOn = value.SafeParseDateTime(); }
        }

        public int Id
        {
            get { return task.Id; }
            set { task.Id = value; }
        }

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
        public string Title
        {
            get { return task.Title; }
            set
            {
                if (value == null)
                    return;

                task.Title = value.Trim();
            }
        }

        public TaskDTO ToTaskDTO()
        {
            return new TaskDTO
            {
                Description = this.Description,
                DueOn = this.DueOn.SafeParseDateTime(),
                Id = this.Id,
                Tags = this.Tags.Select(t => new TagDTO(t.Id, t.Slug, t.Description)).ToArray(),
                Title = this.Title
            };
        }
    }
}