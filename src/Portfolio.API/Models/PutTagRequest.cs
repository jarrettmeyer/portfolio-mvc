namespace Portfolio.API.Models
{
    public class PutTagRequest
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Slug { get; set; }
    }
}