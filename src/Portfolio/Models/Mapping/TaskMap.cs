using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using Portfolio.Web.Models;

namespace Portfolio.Models.Mapping
{
    public class TaskMap : ClassMapping<Task>
    {
        public TaskMap()
        {
            Table("[Tasks]");
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            Property(x => x.Title, map =>
            {
                map.Column("Title");                
                map.Length(256);
            });
            Property(x => x.Description);
            ManyToOne(x => x.Category, map =>
            {
                map.Column(col =>
                {
                    col.Name("CategoryId");
                    col.NotNullable(false);
                });
            });
            ManyToOne(x => x.CurrentStatus, map =>
            {
                map.Column(col =>
                {
                    col.Name("CurrentStatus");
                    col.NotNullable(false);
                });
            });
            Property(x => x.DueOn);
            Property(x => x.IsCompleted);
            Property(x => x.CreatedAt);
            Property(x => x.UpdatedAt);
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

            Bag<TaskStatus>("statuses", map =>
            {
                map.Access(Accessor.Field);
                map.Table("TaskStatuses");
                map.Key(key =>
                {
                    key.Column("Id");
                });
                map.Cascade(Cascade.All|Cascade.DeleteOrphans);
            }, entity =>
            {
                entity.OneToMany(otm =>
                {
                    otm.Class(typeof(TaskStatus));
                });
            });
        }
    }
}
