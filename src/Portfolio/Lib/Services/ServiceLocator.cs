namespace Portfolio.Lib.Services
{
    public abstract class ServiceLocator : IServiceLocator
    {
        private static volatile IServiceLocator instance;

        public static IServiceLocator Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        public abstract TService GetService<TService>() where TService : class;
    }
}