using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

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
     
            // Many-to-Many Tags
            Bag(x => x.Tags, map =>
            {
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Table("[Tasks_Tags]");
                map.Key(key =>
                {
                    key.Column("TaskId");
                });
            }, rel =>
            {
                rel.ManyToMany(map =>
                {                    
                    map.Column("TagId");
                });
            });
        }
    }
}
