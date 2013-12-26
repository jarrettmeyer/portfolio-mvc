using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TagUpdateServiceImpl : ITagUpdateService
    {
        private readonly IRepository repository;
        private Tag tag;

        public TagUpdateServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag UpdateTag(TagDTO tagDto)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTagProperties(tagDto);
                transaction.Commit();
                return tag;
            }
        }

        private void UpdateTagProperties(TagDTO tagDto)
        {
            tag = repository.Load<Tag>(tagDto.Id);
            tag.Slug = tagDto.Slug;
            tag.Description = tagDto.Description.Trim();
            tag.UpdatedAt = Clock.Instance.Now;            
        }
    }
}