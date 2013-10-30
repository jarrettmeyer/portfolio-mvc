using System.Web;

namespace Portfolio.Common.Caching
{
    public class AspNetHttpCache : Cache
    {
        public override void Add(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public override object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public void Clear()
        {            
            HttpRuntime.Close();
        }
    }
}
