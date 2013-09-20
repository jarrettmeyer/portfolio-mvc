namespace Portfolio.Domain.ViewModels
{
    public class TaskInputModel
    {
        private string description;

        public string Category { get; set; }

        public string Description
        {
            get
            {
                if (description == null)
                {
                    return "";
                }
                return description.Trim();
            }
            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }

        public string DueOn { get; set; }

        public int Id { get; set; }

        public string Status { get; set; }
    }
}
