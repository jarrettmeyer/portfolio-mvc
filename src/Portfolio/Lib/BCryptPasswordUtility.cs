namespace Portfolio.Lib
{
    public class BCryptPasswordUtility : IPasswordUtility
    {
        public bool CompareText(string plainText, string hashedText)
        {
            bool areSame = BCrypt.Net.BCrypt.Verify(plainText, hashedText);
            return areSame;
        }

        public string HashText(string plainText)
        {
            var hashText = BCrypt.Net.BCrypt.HashString(plainText);
            return hashText;
        }
    }
}