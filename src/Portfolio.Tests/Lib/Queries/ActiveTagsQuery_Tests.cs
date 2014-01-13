using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib.Queries
{
    [TestFixture]
    public class ActiveTagsQuery_Tests
    {
        private ActiveTagsQuery query;

        [Test]
        public void IsActive_is_true_by_default()
        {
            query = new ActiveTagsQuery();
            query.IsActive.Should().BeTrue();
        }
    }
}
