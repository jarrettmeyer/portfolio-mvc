﻿using Portfolio.Lib.Data;
using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public class TagDeletionServiceImpl : ITagDeletionService
    {
        private Tag tag;
        private readonly IRepository repository;

        public TagDeletionServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Tag DeleteCategory(string id)
        {
            using (var transaction = repository.BeginTransaction())
            {
                tag = repository.Load<Tag>(id);
                tag.IsActive = false;
                tag.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return tag;
            }            
        }
    }
}