using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TagUpdateServiceImpl : ITagUpdateService
    {
        private readonly IRepository repository;

        public TagUpdateServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public void UpdateTag(Tag tag)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTagProperties(tag);
                transaction.Commit();
            }
        }

        private void UpdateTagProperties(Tag tag)
        {
            Tag stub = repository.Load<Tag>(tag.Id);
            stub.Slug = tag.Slug;
            stub.Description = tag.Description.Trim();
            stub.UpdatedAt = Clock.Instance.Now;
        }
    }
}