namespace Portfolio.Data.Models
{
    public class Status
    {
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCompleted { get; set; }
    }
}
