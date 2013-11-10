namespace Portfolio.Web.Lib.Caching
{
    public abstract class Cache : ICache
    {
        private static ICache instance;

        public static ICache Instance
        {
            get { return instance ?? new AspNetHttpCache(); }
            set { instance = value; }
        }

        public abstract void Add(string key, object value);

        public abstract object Get(string key);
    }
}
