using Portfolio.Lib.Models;

namespace Portfolio.Lib.ViewModels
{
    public class TagViewModel
    {
        public TagViewModel()
        {            
        }

        public TagViewModel(int id, string slug, string description)
        {
            this.Id = id;
            this.Slug = slug;
            this.Description = description;
        }

        public TagViewModel(Tag tag)
            : this(tag.Id, tag.Slug, tag.Description)
        {
        }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Slug { get; set; }
    }
}