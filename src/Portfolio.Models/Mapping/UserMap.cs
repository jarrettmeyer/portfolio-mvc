using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace Portfolio.Models.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("[users]");
            Id(x => x.Id, map =>
            {
                map.Column("user_id");
                map.Generator(Generators.Identity);
            });
            Property(x => x.Username, map =>
            {
                map.Column("username");                
            });
            Property(x => x.HashedPassword, map =>
            {
                map.Column("hashed_password");
            });
            Property(x => x.LastLogonAt, map =>
            {
                map.Column("last_logon_at");
            });
            Property(x => x.IsActive, map =>
            {
                map.Column("is_active");
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
     
        }
    }
}
