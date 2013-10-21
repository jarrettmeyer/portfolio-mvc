using System;

namespace Portfolio.Common
{
    public static class Ensure
    {
        public static void ArgumentIsNotNull(object obj, string argumentName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("argumentName");
            }
        }
    }
}
