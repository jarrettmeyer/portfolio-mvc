using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Lib.Models.Mapping
{
    public class TaskMap : ClassMapping<Task>
    {
        public TaskMap()
        {
            Table("[tasks]");
            Id(x => x.Id, map =>
            {
                map.Column("task_id");
                map.Generator(Generators.Identity);
            });
            Property(x => x.Title, map =>
            {
                map.Column("title");
                map.Length(256);
            });
            Property(x => x.Description, map =>
            {
                map.Column("description");
            });
            Property(x => x.DueOn, map =>
            {
                map.Column("due_on");
            });
            Property(x => x.IsCompleted, map =>
            {
                map.Column("is_completed");
            });
            Property(x => x.CreatedAt, map =>
            {
                map.Column("created_at");
            });
            Property(x => x.UpdatedAt, map =>
            {
                map.Column("updated_at");
            });
            Version(x => x.Version, map =>
            {
                map.UnsavedValue(null);
                map.Type(new BinaryBlobType());
                map.Generated(VersionGeneration.Always);
                map.Column(col =>
                {
                    col.Name("version");
                    col.NotNullable(false);
                    col.SqlType("timestamp");
                });
            });       
     
            // Many-to-Many Tags
            Bag(x => x.Tags, map =>
            {
                //map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Table("[tasks_tags]");
                map.Key(key =>
                {
                    key.Column("task_id");
                });
            }, rel =>
            {
                rel.ManyToMany(map =>
                {                    
                    map.Column("tag_id");
                });
            });
        }
    }
}
