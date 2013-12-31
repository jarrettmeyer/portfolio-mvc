using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    [TestFixture]
    public class LogonServiceImplTests
    {
        private LogonCommand credentials;
        private LogonResult logonResult;
        private Mock<IPasswordUtility> mockPasswordUtility;
        private Mock<IRepository> mockRepository;
        private Mock<ITransactionAdapter> mockTransaction;
        private ICommandHandler<LogonCommand, LogonResult> service;

        [SetUp]
        public void Before_each_test()
        {
            mockTransaction = new Mock<ITransactionAdapter> { DefaultValue = DefaultValue.Mock };
            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };
            mockRepository.Setup(x => x.BeginTransaction()).Returns(mockTransaction.Object);

            mockPasswordUtility = new Mock<IPasswordUtility>();

            service = new LogonCommandHandler(mockRepository.Object, mockPasswordUtility.Object);

            credentials = new LogonCommand("tester", "s3cr3t");
        }

        [Test]
        public void It_should_begin_a_transaction()
        {
            service.Handle(credentials);
            mockRepository.Verify(x => x.BeginTransaction(), Times.Once());
        }

        [Test]
        public void It_should_commit_a_transaction()
        {
            service.Handle(credentials);
            mockTransaction.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void It_should_compare_passwords()
        {
            service.Handle(credentials);
            mockPasswordUtility.Verify(x => x.CompareText(credentials.PlainTextPassword, It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void It_should_fail_when_a_user_is_not_found()
        {
            SetRepositoryHitSuccess(false);
            logonResult = service.Handle(credentials);
            logonResult.IsSuccessful.Should().BeFalse();
            logonResult.User.Should().BeAssignableTo<Guest>();
        }

        [Test]
        public void It_should_fail_when_the_password_does_not_match()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(false);
            logonResult = service.Handle(credentials);
            logonResult.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void It_should_fetch_a_user_by_username()
        {
            service.Handle(credentials);
            mockRepository.Verify(x => x.FindOne(It.IsAny<Expression<Func<User, bool>>>()), Times.Once());
        }

        [Test]
        public void It_should_return_successful()
        {
            SetPasswordSuccess(true);
            logonResult = service.Handle(credentials);
            logonResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void It_should_update_LastLogonAt()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(true);
            logonResult = service.Handle(credentials);
            logonResult.User.LastLogonAt.Should().BeCloseTo(DateTime.UtcNow);            
        }

        [Test]
        public void It_should_update_UpdatedAt()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(true);
            logonResult = service.Handle(credentials);
            logonResult.User.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow);
        }

        private void SetPasswordSuccess(bool isSuccessful = true)
        {
            mockPasswordUtility.Setup(x => x.CompareText(It.IsAny<string>(), It.IsAny<string>())).Returns(isSuccessful);
        }

        private void SetRepositoryHitSuccess(bool isSuccessful = true)
        {
            User user = null;
            if (isSuccessful)
            {
                user = new User
                {
                    Username = "tester"
                };    
            }                        
            mockRepository.Setup(x => x.FindOne(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
        }
    }
}
