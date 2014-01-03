using System;
using System.Diagnostics.Contracts;
using Portfolio.Lib.Models;

namespace Portfolio.API.Models
{
    public class GetTagResult
    {
        public GetTagResult(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);

            this.Description = tag.Description;
            this.Id = tag.Id;
            this.IsActive = tag.IsActive;
            this.Slug = tag.Slug;
        }

        public string Description { get; set; }

        public int Id { get; set; }

        public bool IsActive { get; set; }

        public string Slug { get; set; }
    }
}