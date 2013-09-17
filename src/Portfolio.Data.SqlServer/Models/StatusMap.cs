using NHibernate.Mapping.ByCode.Conformist;

namespace Portfolio.Data.Models
{
    public class StatusMap : ClassMapping<Status>
    {
        public StatusMap()
        {
            Table("Statuses");
            Id(x => x.Id);
            Property(x => x.Description);
            Property(x => x.IsCompleted);
        }
    }
}
