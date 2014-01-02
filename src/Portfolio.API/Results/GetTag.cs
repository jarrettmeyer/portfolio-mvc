using Portfolio.Lib.Models;

namespace Portfolio.API.Results
{
    public class GetTag
    {
        public GetTag(Tag tag)
        {
            this.Description = tag.Description;
            this.Id = tag.Id;
            this.Slug = tag.Slug;
        }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Slug { get; set; }
    }
}