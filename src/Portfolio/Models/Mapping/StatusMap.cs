using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Portfolio.Models.Mapping
{
    public class StatusMap : ClassMapping<Status>
    {
        public StatusMap()
        {
            Table("Statuses");
            Id(x => x.Id);
            Property(x => x.Description);
            Property(x => x.IsCompleted);
            Property(x => x.IsDefaultStatus);

            Bag(x => x.Workflows, map =>
            {
                map.Cascade(Cascade.All);
                map.Key(key =>
                {
                    key.Column("[FromStatus]");
                });
            }, action =>
            {
                action.OneToMany();
            });
        }
    }
}
