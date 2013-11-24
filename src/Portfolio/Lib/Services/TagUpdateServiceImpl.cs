﻿using System;
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
                tag = repository.Load<Tag>(tagInputModel.Id);
                tag.Description = tagInputModel.Description.Trim();
                tag.UpdatedAt = DateTime.UtcNow;
                transaction.Commit();
                return tag;
            }            
        }
    }
}