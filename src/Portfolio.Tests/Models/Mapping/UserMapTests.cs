using System;
using System.Diagnostics;
using FluentAssertions;
using NHibernate;
using NHibernate.Exceptions;
using NHibernate.Linq;
using NUnit.Framework;
using Portfolio.Lib;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class UserMapTests
    {
        private ISession session;
        private User user;

        [TestFixtureSetUp]
        public void Before_all_tests()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [SetUp]
        public void Before_each_test()
        {
            
        }

        [TearDown]
        public void After_each_test()
        {
            TestBootstrapper.DeleteAll<User>();
        }

        [Test]
        public void Can_save_a_new_user()
        {
            Action saveUserAction = () =>
            {
                using (session = NHibernateConfig.SessionFactory.OpenSession())
                {
                    user = CreateUser();
                    session.Save(user);
                    //session.Flush();
                }
            };
            saveUserAction.ShouldNotThrow<Exception>();
        }

        [Test]
        public void Saving_a_duplicate_username_should_throw_an_exception()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var user1 = CreateUser();
                var user2 = CreateUser();

                Action saveAction = () =>
                {
                    session.Save(user1);
                    session.Save(user2);
                    session.Flush();
                };

                saveAction.ShouldThrow<GenericADOException>();
            }
        }

        [Test]
        public void Version_is_set_after_save()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                user = CreateUser();
                user.Version.Should().BeNull();
                session.Save(user);
                session.Flush();
            }
            string versionString = user.Version.ToBase64String();
            Debug.WriteLine("User version: " + versionString);
            user.Version.Should().NotBeNull();
            user.Version.Length.Should().Be(8);
        }

        private User CreateUser()
        {
            return new User
            {
                Username = "tester",
                HashedPassword = "tester",
                LastLogonAt = null,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
