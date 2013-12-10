namespace Portfolio.Lib.Models
{
    /// <summary>
    /// Represents an entity that supports versioning.
    /// </summary>
    public interface IVersionedEntity<TId>
    {
        TId Id { get; set; }
        byte[] Version { get; set; }
    }
}
