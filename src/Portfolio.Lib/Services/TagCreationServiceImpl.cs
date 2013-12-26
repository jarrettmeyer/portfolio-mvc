using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TagCreationServiceImpl : ITagCreationService
    {
        private readonly IRepository repository;
        private Tag tag;
        private ITransactionAdapter transaction;

        public TagCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;            
        }

        public virtual Tag CreateTag(TagDTO tagDto)
        {
            using (transaction = repository.BeginTransaction())
            {
                tag = new Tag();
                SetTagProperties(tagDto);
                PersistNewTag();
                return tag;
            }
        }

        private void PersistNewTag()
        {
            repository.Add(tag);
            transaction.Commit();
        }

        private void SetTagProperties(TagDTO tagDto)
        {
            tag.Slug = tagDto.Slug;
            tag.Description = tagDto.Description;
            tag.IsActive = true;
            tag.CreatedAt = Clock.Instance.Now;
            tag.UpdatedAt = Clock.Instance.Now;
        }
    }
}