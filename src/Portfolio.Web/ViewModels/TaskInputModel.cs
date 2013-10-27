using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.ViewModels
{
    public class TaskInputModel
    {
        private string description;

        public IDictionary<int, string> Categories { get; set; }

        public int SelectedCategory { get; set; }

        [Required]
        public string Description
        {
            get
            {
                if (description == null)
                {
                    return "";
                }
                return description.Trim();
            }
            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }

        public string DueOn { get; set; }

        public int Id { get; set; }

        public string Title
        {
            get { return Id == 0 ? "New Task" : "Edit Task"; }
        }
    }
}