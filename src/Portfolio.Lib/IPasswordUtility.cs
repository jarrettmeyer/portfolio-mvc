namespace Portfolio.Lib
{
    public interface IPasswordUtility
    {
        bool CompareText(string plainText, string hashedText);
        string HashText(string plainText);
    }
}