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
        private Category category;
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
            mockRepository.Verify(x => x.Add(It.IsAny<Category>()), Times.Once());
        }

        [Test]
        public void It_sets_the_description()
        {
            categoryInputModel.Description = "This is a test";
            category = service.CreateCategory(categoryInputModel);
            category.Description.Should().Be("This is a test");
        }

        [Test]
        public void It_sets_the_new_category_as_active()
        {
            category = service.CreateCategory(categoryInputModel);
            category.IsActive.Should().BeTrue();
        }
    }
}
