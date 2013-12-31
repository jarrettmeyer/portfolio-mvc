using System;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Data
{
    [TestFixture]
    public class NHibernateRepositoryTests
    {
        private IRepository repository;

        [SetUp]
        public void Before_each_test()
        {
            var session = NHibernateConfig.SessionFactory.OpenSession();
            repository = new NHibernateRepository(session);
        }

        [TearDown]
        public void After_each_test()
        {
            repository.Dispose();
            TestBootstrapper.DeleteAll<Tag>();
            TestBootstrapper.DeleteAll<User>();
        }

        [Test]
        public void Adding_duplicate_record_throws_an_exception()
        {
            Action addAction = () =>
            {
                repository.Add(CreateUser());
                repository.Add(CreateUser());
            };

            addAction.ShouldThrow<UniqueRecordViolationException>();
        }

        [Test]
        public void Is_valid_class_definition()
        {
            repository.Should().NotBeNull();
            repository.Should().BeAssignableTo<IRepository>();
        }

        private static User CreateUser()
        {
            var user = new User
            {
                Username = "tester",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            user.SetHashedPassword("junk", new FakePasswordUtility());
            return user;
        }


    }
}
