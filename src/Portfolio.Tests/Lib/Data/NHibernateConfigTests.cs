using NHibernate;
using NUnit.Framework;

namespace Portfolio.Lib.Data
{
    [TestFixture]
    public class NHibernateConfigTests
    {
        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [Test]
        public void Can_create_session_factory()
        {
            var sessionFactory = NHibernateConfig.SessionFactory;
            Assert.IsInstanceOf<ISessionFactory>(sessionFactory);
        }
    }
}
