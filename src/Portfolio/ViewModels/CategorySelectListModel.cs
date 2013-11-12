namespace Portfolio.ViewModels
{
    public class CategorySelectListModel
    {
        private readonly string description;
        private readonly int id;

        public CategorySelectListModel(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public string Description
        {
            get { return description; }
        }

        public int Id
        {
            get { return id; }
        }
    }
}