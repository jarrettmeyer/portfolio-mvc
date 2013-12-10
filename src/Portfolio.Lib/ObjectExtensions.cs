using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Lib
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object o)
        {
            if (o == null)
                return new Dictionary<string, object>();

            var readableProperties = o.GetType().GetProperties().Where(p => p.CanRead);
            return readableProperties.ToDictionary(property => property.Name, property => property.GetValue(o));
        }
    }
}
