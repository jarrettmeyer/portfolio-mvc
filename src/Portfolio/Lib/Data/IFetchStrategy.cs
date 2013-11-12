namespace Portfolio.Lib.Data
{
    public interface IFetchStrategy<T>
    {
        void ApplyStrategy(IRepository repository);
    }
}