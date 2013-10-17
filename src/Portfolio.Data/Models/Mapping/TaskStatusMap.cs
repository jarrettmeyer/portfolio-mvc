using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Data.Models
{
    public class TaskStatusMap : ClassMapping<TaskStatus>
    {
        public TaskStatusMap()
        {
            Table("[TaskStatuses]");
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            ManyToOne(x => x.Task, map =>
            {
                map.Column(col => col.Name("[TaskId]"));
            });
            ManyToOne(x => x.Status, map =>
            {
                map.Column(col => col.Name("[Status]"));
            });
            Property(x => x.IsCompleted);
            Property(x => x.Comment);
            Property(x => x.IPAddress);
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
