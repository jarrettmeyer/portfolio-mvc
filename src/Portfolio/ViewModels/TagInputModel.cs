using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Models;

namespace Portfolio.ViewModels
{
    public class TagInputModel
    {
        private readonly Tag tag;

        public TagInputModel()
            : this(new Tag())
        {
        }

        public TagInputModel(Tag tag)
        {
            this.tag = tag;            
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
        public string Description
        {
            get { return tag.Description; }
            set { tag.Description = value; }
        }

        public object FormCss
        {
            get { return new { @class = "form-horizontal" }; }
        }

        public FormMethod FormMethod
        {
            get { return FormMethod.Post; }
        }

        public int Id
        {
            get { return tag.Id; }
            set { tag.Id = value; }
        }

        public bool IsNew
        {
            get { return Id == 0; }
        }

        public string PageTitle
        {
            get { return IsNew ? "New Tag" : "Edit Tag"; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Slug is required")]
        [RegularExpression("[a-z0-9\\.\\-_]+")]
        [DataType(DataType.Text)]
        public string Slug
        {
            get { return tag.Slug; }
            set { tag.Slug = value; }
        }

        public CreateTagCommand ToCreateTagCommand()
        {
            return new CreateTagCommand
            {
                Description = this.Description,
                Slug = this.Slug
            };
        }

        public UpdateTagCommand ToUpdateTagCommand()
        {
            return new UpdateTagCommand
            {
                Description = this.Description,
                Id = this.Id,
                Slug = this.Slug
            };
        }
    }
}