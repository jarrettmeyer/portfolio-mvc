using System.Collections;
using System.Linq;
using System.Web;

namespace Portfolio.Lib.Caching
{
    public class AspNetHttpCache : Cache
    {
        public override void Add(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public override void Clear()
        {
            var keys = from DictionaryEntry entry in HttpRuntime.Cache
                select entry.Key.ToString();

            foreach (var key in keys)
                HttpRuntime.Cache.Remove(key);
        }

        public override object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
    }
}
