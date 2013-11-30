using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Portfolio.Models.Mapping
{
    public class PasswordTokenMap : ClassMapping<PasswordToken>
    {
        public PasswordTokenMap()
        {
            Table("[password_tokens]");
            Id(x => x.Token, map =>
            {
                map.Column("token");
                map.Generator(Generators.Assigned);
            });
            ManyToOne(x => x.User, map =>
            {
                map.Column("user_id");
            });
            Property(x => x.ExpiresAt, map =>
            {
                map.Column("expires_at");
            });
            Property(x => x.CreatedAt, map =>
            {
                map.Column("created_at");
            });
        }
    }
}
