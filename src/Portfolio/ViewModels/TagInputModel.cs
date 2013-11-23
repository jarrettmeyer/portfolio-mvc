using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TagInputModel
    {
        public TagInputModel()
            : this(new Tag())
        {            
        }

        public TagInputModel(Tag tag)
        {
            Description = tag.Description;
            Id = tag.Id;
        }

        public string ActionName
        {
            get { return IsNew ? "New" : "Edit"; }
        }

        public string ControllerName
        {
            get { return "Tags"; }
        }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; }

        public object FormCss
        {
            get { return new { @class = "form-horizontal" }; }
        }

        public FormMethod FormMethod
        {
            get { return FormMethod.Post; }
        }

        public int Id { get; set; }

        public bool IsNew
        {
            get { return Id == 0; }
        }

        public string PageTitle
        {
            get { return IsNew ? "New Tag" : "Edit Tag"; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Slug is required")]
        [RegularExpression(@"[a-z0-9\.\_\-]+")]
        public string Slug { get; set; }
    }
}