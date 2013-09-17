using NHibernate;
using NUnit.Framework;

namespace Portfolio.Data
{
    [TestFixture]
    public class NHibernateConfigTests
    {
        [SetUp]
        public void before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [Test]
        public void can_create_session_factory()
        {
            var sessionFactory = NHibernateConfig.SessionFactory;
            Assert.IsInstanceOf<ISessionFactory>(sessionFactory);
        }
    }
}
