using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CreateTagCommand : ICommand<Tag>
    {
        public CreateTagCommand()
        {
        }

        public CreateTagCommand(string slug = null, string description = null)
        {
            this.Slug = slug;
            this.Description = description;
        }

        public string Description { get; set; }

        public string Slug { get; set; }
    }
}
