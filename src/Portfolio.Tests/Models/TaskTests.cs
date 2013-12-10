using System;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Models;

namespace Portfolio.Models
{
    [TestFixture]
    public class TaskTests
    {
        private Task task;

        [SetUp]
        public void Before_each_test()
        {
            task = new Task();
        }

        [Test]
        public void AddTag_will_not_created_duplicates()
        {
            task.Tags.Count.Should().Be(0);

            task.AddTag(new Tag { Id = 1, Slug = "tag-1" });
            task.AddTag(new Tag { Id = 1, Slug = "tag-1" });

            task.Tags.Count.Should().Be(1);
            task.Tags[0].Id.Should().Be(1);
            task.Tags[0].Slug.Should().Be("tag-1");
        }

        [Test]
        public void Complete_will_set_CompletedAt_to_the_current_time()
        {
            task.CompletedAt.Should().NotHaveValue();
            task.Complete();
            task.CompletedAt.Value.Should().BeCloseTo(DateTime.UtcNow);
        }

        [Test]
        public void Complete_will_set_IsCompleted_to_true()
        {
            task.IsCompleted.Should().BeFalse();
            task.Complete();
            task.IsCompleted.Should().BeTrue();
        }

        [Test]
        public void Default_categories_is_empty()
        {
            task.Tags.Should().NotBeNull();
            task.Tags.Count.Should().Be(0);
        }

        [Test]
        public void RemoveTag_will_remove_a_tag()
        {
            task.Tags.Add(new Tag { Id = 1 });
            task.Tags.Add(new Tag { Id = 2 });

            task.Tags.Count.Should().Be(2);

            task.RemoveTag(1);

            task.Tags.Count.Should().Be(1);
            task.Tags[0].Id.Should().Be(2);
        }
    }
}
