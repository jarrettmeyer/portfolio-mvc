namespace Portfolio.Lib.DTOs
{
    public class TagDTO
    {
        public TagDTO() { }

        public TagDTO(int id, string slug = null, string description = null)
        {
            this.Id = id;
            this.Slug = slug;
            this.Description = description;
        }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Slug { get; set; }
    }
}
