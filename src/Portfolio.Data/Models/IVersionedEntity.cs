namespace Portfolio.Data.Models
{
    public interface IVersionedEntity
    {
        int Id { get; set; }
        byte[] Version { get; set; }
    }
}
