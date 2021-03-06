﻿using System;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class PasswordTokenMapTests
    {
        private PasswordToken passwordToken;
        private ISession session;
        private User user;
        private int userId;

        [SetUp]
        public void Before_each_test()
        {
            TestBootstrapper.DeleteAll<User>();
            CreateUser();
        }

        [TearDown]
        public void After_each_test()
        {
            TestBootstrapper.DeleteAll<PasswordToken>();
            TestBootstrapper.DeleteAll<User>();
        }

        [Test]
        public void Can_save_a_new_password_token()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                user = session.Load<User>(userId);
                passwordToken = PasswordToken.GenerateForUser(user);

                Action saveAction = () =>
                {
                    session.Save(passwordToken);
                    session.Flush();
                };

                saveAction.ShouldNotThrow<Exception>();
            }
        }

        private void CreateUser()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                user = new User
                {
                    Username = "tester",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                user.SetHashedPassword("hashed_password", new FakePasswordUtility());
                session.Save(user);
                session.Flush();
                userId = user.Id;
            }
        }
    }
}
