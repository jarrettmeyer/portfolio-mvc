using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    [TestFixture]
    public class CategoryCreationServiceImplTests
    {
        private Tag tag;
        private TagInputModel tagInputModel;
        private Mock<IRepository> mockRepository;
        private ITagCreationService service;

        [SetUp]
        public void Before_each_test()
        {
            // Configure the input model
            tagInputModel = new TagInputModel { Description = "" };

            // Configure mock repository
            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };

            // Configure service
            service = new TagCreationServiceImpl(mockRepository.Object);
        }

        [Test]
        public void It_adds_a_category_to_the_repository()
        {
            service.CreateCategory(tagInputModel);
            mockRepository.Verify(x => x.Add(It.IsAny<Tag>()), Times.Once());
        }

        [Test]
        public void It_sets_the_description()
        {
            tagInputModel.Description = "This is a test";
            tag = service.CreateCategory(tagInputModel);
            tag.Description.Should().Be("This is a test");
        }

        [Test]
        public void It_sets_the_new_category_as_active()
        {
            tag = service.CreateCategory(tagInputModel);
            tag.IsActive.Should().BeTrue();
        }
    }
}
