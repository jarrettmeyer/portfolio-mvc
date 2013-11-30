using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class TagUpdateServiceImpl : ITagUpdateService
    {
        private Tag tag;
        private readonly IRepository repository;

        public TagUpdateServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag UpdateCategory(TagInputModel tagInputModel)
        {
            using (var transaction = repository.BeginTransaction())
            {
                tag = repository.Load<Tag>(tagInputModel.OriginalId);
                tag.Id = tagInputModel.Id;
                tag.Description = tagInputModel.Description.Trim();
                tag.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return tag;
            }            
        }
    }
}