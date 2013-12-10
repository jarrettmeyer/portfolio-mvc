﻿using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

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
                tag = repository.Load<Tag>(tagInputModel.Id);
                tag.Slug = tagInputModel.Slug;
                tag.Description = tagInputModel.Description.Trim();
                tag.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return tag;
            }            
        }
    }
}