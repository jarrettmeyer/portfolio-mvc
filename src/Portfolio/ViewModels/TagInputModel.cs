using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TagInputModel
    {
        public TagInputModel()
        {
            IsNew = true;
        }

        public TagInputModel(Tag tag)
        {
            IsNew = false;
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

        public bool IsNew { get; set; }
        
        public string PageTitle
        {
            get { return IsNew ? "New Tag" : "Edit Tag"; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Slug is required")]
        //[RegularExpression("[a-z0-9\\.\\_\\-]+")]
        public string Id { get; set; }
    }
}