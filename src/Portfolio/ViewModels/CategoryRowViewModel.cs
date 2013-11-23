using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class CategoryRowViewModel
    {
        private readonly Tag tag;

        public CategoryRowViewModel(Tag tag)
        {
            this.tag = tag;
        }

        public bool AllowDelete
        {
            get { return tag.IsActive; }
        }

        public bool AllowEdit
        {
            get { return tag.IsActive; }
        }

        public string Description
        {
            get { return (tag.Description ?? "").Trim(); }
        }

        public int Id
        {
            get { return tag.Id; }
        }

        public string IsActive
        {
            get { return tag.IsActive.ToYesNo(); }
        }

        public string RowCss
        {
            get
            {
                string css = "Tag";
                if (!tag.IsActive)
                    css += " inactive";
                return css;
            }
        }
    }
}