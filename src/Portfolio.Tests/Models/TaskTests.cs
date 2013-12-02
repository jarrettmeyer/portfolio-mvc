using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Models
{
    [TestFixture]
    public class TaskTests
    {
        private Task task;

        [Test]
        public void AddTag_will_not_created_duplicates()
        {
            task = new Task();

            task.AddTag(new Tag { Id = 1, Slug = "tag-1" });
            task.AddTag(new Tag { Id = 1, Slug = "tag-1" });

            task.Tags.Count.Should().Be(1);
            task.Tags[0].Id.Should().Be(1);
            task.Tags[0].Slug.Should().Be("tag-1");
        }

        [Test]
        public void Default_categories_is_empty()
        {
            task = new Task();
            task.Tags.Should().NotBeNull();
            task.Tags.Count.Should().Be(0);
        }

        [Test]
        public void RemoveTag_will_remove_a_tag()
        {
            task = new Task();
            task.Tags.Add(new Tag { Id = 1 });
            task.Tags.Add(new Tag { Id = 2 });

            task.Tags.Count.Should().Be(2);

            task.RemoveTag(1);

            task.Tags.Count.Should().Be(1);
            task.Tags[0].Id.Should().Be(2);
        }
    }
}
