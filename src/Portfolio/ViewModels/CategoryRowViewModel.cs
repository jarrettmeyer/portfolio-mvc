using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class CategoryRowViewModel
    {
        private readonly Category category;

        public CategoryRowViewModel(Category category)
        {
            this.category = category;
        }

        public bool AllowDelete
        {
            get { return category.IsActive; }
        }

        public bool AllowEdit
        {
            get { return category.IsActive; }
        }

        public string Description
        {
            get { return (category.Description ?? "").Trim(); }
        }

        public int Id
        {
            get { return category.Id; }
        }

        public string IsActive
        {
            get { return category.IsActive.ToYesNo(); }
        }

        public string RowCss
        {
            get
            {
                string css = "category";
                if (!category.IsActive)
                    css += " inactive";
                return css;
            }
        }
    }
}