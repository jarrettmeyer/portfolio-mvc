using Portfolio.Lib.Commands;

namespace Portfolio.API.Models
{
    public class PostTaskRequest
    {
        private int[] tagIds;

        public string Description { get; set; }

        public long? DueOn { get; set; }

        public int[] TagIds
        {
            get { return tagIds ?? new int[] { }; }
            set { tagIds = value; }
        }

        public string Title { get; set; }

        public CreateTaskCommand ToCreateTaskCommand()
        {
            return new CreateTaskCommand
            {
                Description = this.Description,
                DueOn = null,
                TagIds = this.TagIds,
                Title = this.Title
            };
        }
    }
}