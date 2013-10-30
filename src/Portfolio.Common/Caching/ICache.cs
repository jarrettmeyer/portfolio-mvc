namespace Portfolio.Common.Caching
{
    public interface ICache
    {
        void Add(string key, object value);

        object Get(string key);
    }
}
