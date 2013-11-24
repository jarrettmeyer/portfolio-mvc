namespace Portfolio.ViewModels
{
    public class TagLabelViewModel
    {
        public TagLabelViewModel()
        {            
        }

        public TagLabelViewModel(string description, string slug)
        {
            Description = description;
            Slug = slug;
        }

        public string Description { get; set; }
        public string Slug { get; set; }
    }
}