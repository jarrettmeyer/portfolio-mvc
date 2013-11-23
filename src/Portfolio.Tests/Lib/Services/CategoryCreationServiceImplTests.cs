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
        private CategoryInputModel categoryInputModel;
        private Mock<IRepository> mockRepository;
        private ICategoryCreationService service;

        [SetUp]
        public void Before_each_test()
        {
            // Configure the input model
            categoryInputModel = new CategoryInputModel { Description = "" };

            // Configure mock repository
            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };

            // Configure service
            service = new CategoryCreationServiceImpl(mockRepository.Object);
        }

        [Test]
        public void It_adds_a_category_to_the_repository()
        {
            service.CreateCategory(categoryInputModel);
            mockRepository.Verify(x => x.Add(It.IsAny<Tag>()), Times.Once());
        }

        [Test]
        public void It_sets_the_description()
        {
            categoryInputModel.Description = "This is a test";
            tag = service.CreateCategory(categoryInputModel);
            tag.Description.Should().Be("This is a test");
        }

        [Test]
        public void It_sets_the_new_category_as_active()
        {
            tag = service.CreateCategory(categoryInputModel);
            tag.IsActive.Should().BeTrue();
        }
    }
}
