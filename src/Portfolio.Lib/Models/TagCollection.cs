using System.Collections;
using System.Collections.Generic;

namespace Portfolio.Lib.Models
{
    public class TagCollection : IEnumerable<Tag>
    {
        private readonly IEnumerable<Tag> tags;

        public TagCollection(IEnumerable<Tag> tags)
        {
            this.tags = tags ?? new List<Tag>();
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
