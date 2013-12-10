using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.ViewModels
{
    public class TagInputModel
    {
        public TagInputModel()
        {
            IsNew = true;
        }

        public TagInputModel(Tag tag)
        {
            Description = tag.Description;
            IsNew = false;
            Slug = tag.Slug;
            
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
        [StringLength(30, ErrorMessage = "Description cannot exceed 30 characters")]
        [DataType(DataType.Text)]
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

        public bool IsNew { get; set; }

        public string PageTitle
        {
            get { return IsNew ? "New Tag" : "Edit Tag"; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Slug is required")]
        [RegularExpression("[a-z0-9\\.\\-_]+")]
        [DataType(DataType.Text)]
        public string Slug { get; set; }
    }
}