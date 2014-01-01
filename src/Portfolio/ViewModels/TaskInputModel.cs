using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib;
using Portfolio.Lib.Commands;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.ViewModels
{
    public class TaskInputModel
    {
        private IList<TagViewModel> tags;        

        public TaskInputModel()            
        {            
        }

        public TaskInputModel(Task task)
        {
            Contract.Requires<ArgumentNullException>(task != null);

            this.Description = task.Description;
            this.DueOn = task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "";
            this.Id = task.Id;
            this.Tags = task.Tags.Select(tag => new TagViewModel(tag.Id, tag.Slug, tag.Description)).ToList();
            this.Title = task.Title;
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

        public IList<TagViewModel> Tags
        {
            get { return tags ?? new List<TagViewModel>(); }
            set { tags = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        [StringLength(256)]
        public string Title { get; set; }        

        public CreateTaskCommand ToCreateTaskCommand()
        {
            return new CreateTaskCommand
            {
                Description = this.Description,
                DueOn = this.DueOn.SafeParseDateTime(),
                TagIds = this.Tags.Select(t => t.Id),
                Title = this.Title
            };
        }

        public UpdateTaskCommand ToUpdateTaskCommand()
        {
            return new UpdateTaskCommand
            {
                Description = this.Description,
                DueOn = this.DueOn.SafeParseDateTime(),
                Id = this.Id,
                TagIds = this.Tags.Select(t => t.Id),
                Title = this.Title
            };
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