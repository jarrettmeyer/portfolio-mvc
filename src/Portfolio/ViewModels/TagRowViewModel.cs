using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TagRowViewModel
    {
        public TagRowViewModel(Tag tag)
        {
            Description = tag.Description;
            Id = tag.Id;
            IsActive = tag.IsActive.ToYesNo();
            Slug = tag.Slug;            
        }

        public bool AllowDelete
        {
            get { return IsActive == "Yes"; }
        }

        public bool AllowEdit
        {
            get { return IsActive == "Yes"; }
        }

        public string Description { get; set; }        

        public int Id { get; set; }        

        public string IsActive { get; set; }        

        public string RowCss
        {
            get
            {
                string css = "tag-row";
                if (IsActive == "No")
                    css += " inactive";
                return css;
            }
        }

        public string Slug { get; set; }        
    }
}