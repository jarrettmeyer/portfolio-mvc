using System;
using Portfolio.Lib;

namespace Portfolio
{
    internal class FakePasswordUtility : IPasswordUtility
    {
        public bool CompareText(string plainText, string hashedText)
        {
            return plainText.Equals(hashedText, StringComparison.InvariantCulture);
        }

        public string HashText(string plainText)
        {
            return plainText;
        }
    }
}
