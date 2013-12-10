using System.Diagnostics;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class TagMapTests
    {
        private Tag tag;
        private int tagId;
        private ISession session;

        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [TearDown]
        public void After_each_test()
        {            
            TestBootstrapper.DeleteAll<Tag>();
        }

        [Test]
        public void Can_insert_a_tag()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                InsertTag(description: "This is a test");
            }
            
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                tag = session.Get<Tag>(tagId);
                tag.Description.Should().Be("This is a test");
            }
        }

        [Test]
        public void Default_version_property_is_null()
        {
            tag = new Tag();
            Assert.IsNull(tag.Version);
        }

        [Test]
        public void Version_property_is_not_null_after_loading_from_db()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                InsertTag();
            }
            tag.Version.Should().NotBeNull();
            tag.Version.Should().NotBeEmpty();            
        }

        private void InsertTag(string description = "Test Tag", string slug = "test-tag", bool isActive = true)
        {            
            tag = ObjectMother.NewTag;
            tag.Description = description;
            tag.Slug = slug;
            tag.IsActive = isActive;
            session.Save(tag);
            session.Flush();
            tagId = tag.Id;
            Debug.WriteLine("Inserted new Tag with ID: {0}", tagId);
        }
    }
}
