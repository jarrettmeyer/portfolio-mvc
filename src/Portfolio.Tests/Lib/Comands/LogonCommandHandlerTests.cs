using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib.Comands
{
    [TestFixture]
    public class LogonCommandHandlerTests
    {
        private LogonCommandHandler commandHandler;
        private LogonCommand command;
        private LogonResult logonResult;
        private Mock<IMediator> mockMediator;
        private Mock<IPasswordUtility> mockPasswordUtility;        
        private SessionTests sessionTests;        

        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
            mockMediator = new Mock<IMediator> { DefaultValue = DefaultValue.Mock };
            mockPasswordUtility = new Mock<IPasswordUtility>();
            sessionTests = new SessionTests();
            commandHandler = new LogonCommandHandler(sessionTests.Session, mockMediator.Object, mockPasswordUtility.Object);
            command = new LogonCommand("tester", "s3cr3t");
        }

        [Test]
        public void It_should_begin_a_transaction()
        {
            commandHandler.Handle(command);
            sessionTests.VerifyBeginTransaction();            
        }

        [Test]
        public void It_should_commit_a_transaction()
        {
            commandHandler.Handle(command);
            sessionTests.VerifyCommitTransaction();            
        }

        [Test]
        public void It_should_compare_passwords()
        {
            commandHandler.Handle(command);
            mockPasswordUtility.Verify(x => x.CompareText(command.PlainTextPassword, It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void It_should_fail_when_a_user_is_not_found()
        {
            SetRepositoryHitSuccess(false);
            logonResult = commandHandler.Handle(command);
            logonResult.IsSuccessful.Should().BeFalse();
            logonResult.User.Should().BeAssignableTo<Guest>();
        }

        [Test]
        public void It_should_fail_when_the_password_does_not_match()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(false);
            logonResult = commandHandler.Handle(command);
            logonResult.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void It_should_fetch_a_user_by_username()
        {
            commandHandler.Handle(command);
            mockMediator.Verify(x => x.Request(It.IsAny<UserByUsernameQuery>()), Times.Once());            
        }

        [Test]
        public void It_should_return_successful()
        {
            SetPasswordSuccess(true);
            logonResult = commandHandler.Handle(command);
            logonResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void It_should_update_LastLogonAt()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(true);
            logonResult = commandHandler.Handle(command);
            logonResult.User.LastLogonAt.Should().BeCloseTo(DateTime.UtcNow);            
        }

        [Test]
        public void It_should_update_UpdatedAt()
        {
            SetRepositoryHitSuccess(true);
            SetPasswordSuccess(true);
            logonResult = commandHandler.Handle(command);
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
            mockMediator.Setup(x => x.Request(It.IsAny<UserByUsernameQuery>())).Returns(user);
        }
    }
}
