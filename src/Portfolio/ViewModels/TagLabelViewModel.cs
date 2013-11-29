namespace Portfolio.ViewModels
{
    public class TagLabelViewModel
    {
        public TagLabelViewModel()
        {            
        }

        public TagLabelViewModel(string description, string id)
        {
            Description = description;
            Id = id;
        }

        public string Description { get; set; }
        public string Id { get; set; }
    }
}