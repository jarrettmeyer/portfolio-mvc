using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Data.Models
{
    public class StatusWorkflowMap : ClassMapping<StatusWorkflow>
    {
        public StatusWorkflowMap()
        {
            Table("StatusWorkflows");
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            ManyToOne(x => x.FromStatus, map =>
            {
                map.Column(col =>
                {
                    col.Name("FromStatus");
                });
            });
            ManyToOne(x => x.ToStatus, map =>
            {
                map.Column(col =>
                {
                    col.Name("ToStatus");
                });
            });
            Property(x => x.CreatedAt);
            Version(x => x.Version, map =>
            {
                map.UnsavedValue(null);
                map.Type(new BinaryBlobType());
                map.Generated(VersionGeneration.Always);
                map.Column(col =>
                {
                    col.NotNullable(false);
                    col.SqlType("timestamp");
                });
            });
        }
    }
}
