using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Data.Models
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            Property(x => x.Description);
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
