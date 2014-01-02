using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.API.Results
{
    public class GetTags : IEnumerable<GetTag>
    {
        private readonly List<GetTag> tags = new List<GetTag>();

        public GetTags(IEnumerable<Tag> tags)
        {
            this.tags.AddRange(tags.Select(t => new GetTag(t)));
        }

        public IEnumerator<GetTag> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}