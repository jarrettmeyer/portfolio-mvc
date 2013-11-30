using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Models.Mapping
{
    public class TagMap : ClassMapping<Tag>
    {
        public TagMap()
        {
            Table("[tags]");
            Id(x => x.Id, map =>
            {
                map.Column("tag_id");
                map.Generator(Generators.Identity);
            });
            Property(x => x.Slug, map =>
            {
                map.Column("slug");
                map.NotNullable(true);
            });
            Property(x => x.Description, map =>
            {
                map.Column("description");
                map.NotNullable(true);
            });
            Property(x => x.IsActive, map =>
            {
                map.Column(col =>
                {
                    col.Name("is_active");
                    col.Default("(1)");
                });
                map.NotNullable(true);
            });
            Property(x => x.CreatedAt, map =>
            {
                map.Column("created_at");
                map.NotNullable(true);
            });
            Property(x => x.UpdatedAt, map =>
            {
                map.Column("updated_at");
                map.NotNullable(true);
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
        }
    }
}
