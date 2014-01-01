using System;
using System.Diagnostics.Contracts;

namespace Portfolio.Lib
{
    public static class ByteExtensions
    {
        public static string ToBase64String(this byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
        {
            Contract.Requires<ArgumentNullException>(bytes != null);
            var bytesAsString = Convert.ToBase64String(bytes, options);
            return bytesAsString;
        }
    }
}