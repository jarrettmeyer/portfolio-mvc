namespace Portfolio.Web.Models
{
    /// <summary>
    /// Represents an entity that supports versioning.
    /// </summary>
    public interface IVersionedEntity
    {
        int Id { get; set; }
        byte[] Version { get; set; }
    }
}
