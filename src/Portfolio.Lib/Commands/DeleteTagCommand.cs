using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class DeleteTagCommand : ICommand<Tag>
    {
        public int Id { get; set; }
    }
}
