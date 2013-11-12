namespace Portfolio.ViewModels
{
    public class FlashMessage
    {
        public FlashMessage(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; private set; }

        public string Message { get; private set; }
    }
}