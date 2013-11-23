using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Models
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void Default_categories_is_empty()
        {
            var task = new Task();
            task.Tags.Should().NotBeNull();
            task.Tags.Count.Should().Be(0);
        }
    }
}
