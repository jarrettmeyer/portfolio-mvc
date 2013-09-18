namespace Portfolio.Common.Logging
{
    public interface ILogWriter
    {
        void WriteDebug(string message);
        void WriteError(string message);
    }
}
