using Ninject;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture, Category("Slow tests")]
    public class NinjectConfig_Tests
    {
        private IKernel kernel;

        [SetUp]
        public void Before_each_test()
        {
            kernel = new StandardKernel();
        }

        [Test]
        public void Is_valid_configuration()
        {
            RegisterServices();
            Assert.Pass("Everything should have succeeded!");
        }

        private void RegisterServices()
        {
            NinjectConfig.RegisterServices(kernel);
        }
    }
}
