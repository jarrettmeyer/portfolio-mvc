using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    [TestFixture]
    public class TagCreationServiceImplTests
    {
        private Tag tag;        
        private Mock<IRepository> mockRepository;
        private ITagCreationService service;

        [SetUp]
        public void Before_each_test()
        {
            // Configure the tag
            tag = new Tag { Slug = "test", Description = "Test" };

            // Configure mock repository
            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };

            // Configure service
            service = new TagCreationServiceImpl(mockRepository.Object);
        }

        [Test]
        public void It_adds_a_category_to_the_repository()
        {
            service.CreateTag(tag);
            mockRepository.Verify(x => x.Add(It.IsAny<Tag>()), Times.Once());
        }

        [Test]
        public void It_sets_the_new_category_as_active()
        {
            service.CreateTag(tag);
            tag.IsActive.Should().BeTrue();
        }
    }
}
