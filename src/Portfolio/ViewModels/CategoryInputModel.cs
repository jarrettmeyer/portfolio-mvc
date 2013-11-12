using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.ViewModels
{
    public class CategoryInputModel
    {
        public string ActionName
        {
            get { return IsNew ? "New" : "Edit"; }
        }

        public string ControllerName
        {
            get { return "Categories"; }
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
            get { return IsNew ? "New Category" : "Edit Category"; }
        }
    }
}