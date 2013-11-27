using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Models.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("[Users]");
            Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            Property(x => x.Username);
            Property(x => x.HashedPassword);
            Property(x => x.LastLogonAt);
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
