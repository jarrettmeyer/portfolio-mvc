namespace Portfolio.Common
{
    /// <summary>
    /// An abstraction for getting values related to the current application user.
    /// </summary>
    public interface IUserSettings
    {
        /// <summary>
        /// Gets the IP Address of the user.
        /// </summary>
        string IPAddress { get; }
    }
}
