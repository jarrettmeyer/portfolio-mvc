using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TagByIdQuery : IQuery<Tag>
    {
        public TagByIdQuery() { }

        public TagByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
