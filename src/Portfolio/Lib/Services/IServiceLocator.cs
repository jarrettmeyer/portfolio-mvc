namespace Portfolio.Lib.Services
{
    public interface IServiceLocator
    {
        /// <summary>
        /// Get a service from the service locator.
        /// </summary>
        TService GetService<TService>() where TService : class;
    }
}