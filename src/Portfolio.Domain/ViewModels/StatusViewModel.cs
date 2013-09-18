namespace Portfolio.Domain.ViewModels
{
    public class StatusViewModel
    {
        private string description = "";
        private string id = "";

        public string Description
        {
            get { return description; }
            set
            {
                if (value != null)
                    description = value;
            }
        }
        
        public string Id
        {
            get { return id; }
            set
            {
                if (value != null)
                    id = value;
            }
        }        
    }
}
