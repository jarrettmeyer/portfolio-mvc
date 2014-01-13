namespace Portfolio.Lib.Caching
{
    public interface ICache
    {
        void Add(string key, object value);

        void Clear();

        object Get(string key);
    }
}
