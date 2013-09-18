namespace Portfolio.Domain.ViewModels
{
    public class CategoryViewModel
    {
        private string description = "";
        private int id = 0;

        public string Description
        {
            get { return description; }
            set
            {
                if (value != null)
                    description = value;
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id >= 0)
                    id = value;
            }
        }
    }
}
