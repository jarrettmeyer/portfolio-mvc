using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    [TestFixture]
    public class TagUpdateServiceImplTests
    {
        private Mock<IRepository> mockRepository;
        private ITagUpdateService service;
        private Tag tag;
        private TagDTO tagDto;

        [SetUp]
        public void Before_each_test()
        {
            tagDto = new TagDTO { Id = 123, Description = "Something", Slug = "something" };

            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };
            mockRepository.Setup(x => x.Load<Tag>(123)).Returns(new Tag { Id = 123 });

            service = new TagUpdateServiceImpl(mockRepository.Object);
        }

        [Test]
        public void It_should_fetch_a_tag()
        {
            service.UpdateTag(tagDto);
            mockRepository.Verify(x => x.Load<Tag>(123), Times.Once());
        }

        [Test]
        public void It_should_update_properties()
        {
            tag = service.UpdateTag(tagDto);
            tag.Slug.Should().Be("something");
            tag.Description.Should().Be("Something");
        }
    }
}
