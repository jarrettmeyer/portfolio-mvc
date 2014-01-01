using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TagByIdQuery : IQuery<Tag>
    {
        public int Id { get; set; }
    }
}
