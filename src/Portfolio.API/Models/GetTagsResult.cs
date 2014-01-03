using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.API.Models
{
    public class GetTagsResult : IEnumerable<GetTagResult>
    {
        private readonly List<GetTagResult> tags = new List<GetTagResult>();

        public GetTagsResult(IEnumerable<Tag> tags)
        {
            Contract.Requires<ArgumentNullException>(tags != null);
            this.tags.AddRange(tags.Select(t => new GetTagResult(t)));
        }

        public IEnumerator<GetTagResult> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}