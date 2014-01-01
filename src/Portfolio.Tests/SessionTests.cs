using Moq;
using NHibernate;

namespace Portfolio
{
    public class SessionTests
    {
        private readonly Mock<ISession> mockSession;
        private readonly Mock<ITransaction> mockTransaction;

        public SessionTests()
        {
            mockTransaction = new Mock<ITransaction> { DefaultValue = DefaultValue.Mock };
            mockSession = new Mock<ISession> { DefaultValue = DefaultValue.Mock };
            mockSession.Setup(x => x.BeginTransaction()).Returns(mockTransaction.Object);
        }

        public ISession Session
        {
            get { return mockSession.Object; }
        }

        public ITransaction Transaction
        {
            get { return mockTransaction.Object; }
        }

        public void VerifyBeginTransaction(Times? times = null)
        {
            if (times == null)
                times = Times.Once();

            mockSession.Verify(x => x.BeginTransaction(), times.Value);
        }

        public void VerifyCommitTransaction(Times? times = null)
        {
            if (times == null)
                times = Times.Once();

            mockTransaction.Verify(x => x.Commit(), times.Value);
        }
    }
}
