using System.Diagnostics;
using NUnit.Framework;
using Portfolio.Lib.Data;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class CategoryMapTests
    {
        private Category category;
        private int categoryId;

        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [TearDown]
        public void After_each_test()
        {
            TestBootstrapper.DeleteAllCategories();
        }

        [Test]
        public void Can_insert_a_category()
        {
            category = TestBootstrapper.InsertNewCategory("This is a test");
            categoryId = category.Id;
            Debug.WriteLine("Inserted new category with ID: {0}", categoryId);
            
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                category = session.Get<Category>(categoryId);
                Assert.AreEqual("This is a test", category.Description);
            }
        }

        [Test]
        public void Default_version_property_is_null()
        {
            category = new Category();
            Assert.IsNull(category.Version);
        }

        [Test]
        public void Version_property_is_not_null_after_loading_from_db()
        {
            category = TestBootstrapper.InsertNewCategory("Testing Version");
            Assert.IsNotNull(category.Version);
            Assert.IsNotEmpty(category.Version);
        }
    }
}
