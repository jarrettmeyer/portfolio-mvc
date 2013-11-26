using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Models.Mapping
{
    public class TagMap : ClassMapping<Tag>
    {
        public TagMap()
        {
            Table("Tags");
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            Property(x => x.Description);
            Property(x => x.Slug);
            Property(x => x.IsActive, map =>
            {
                map.Column(col =>
                {
                    col.Default("(1)");
                });
                map.NotNullable(true);
            });
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
        }
    }
}
