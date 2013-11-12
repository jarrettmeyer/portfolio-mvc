namespace Portfolio.Lib
{
    public static class BooleanExtensions
    {
        public static string ToYesNo(this bool b, string valueForTrue = "Yes", string valueForFalse = "No")
        {
            return b ? valueForTrue : valueForFalse;
        }
    }
}