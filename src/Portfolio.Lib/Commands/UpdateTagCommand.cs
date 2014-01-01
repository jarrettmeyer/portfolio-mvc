using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class UpdateTagCommand : ICommand<Tag>
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Slug { get; set; }
    }
}
