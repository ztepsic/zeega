using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping {
    class AppTenantMapping : ClassMapping<AppTenant> {
        public AppTenantMapping() {
            Schema(MappingConstants.APP_SCHEMA);
            Table("AppTenants");

            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Name,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });
            Property(x => x.Description);
            Property(x => x.IsPrimary,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });
            Component(x => x.LanguageCode, m => m.Access(Accessor.NoSetter));

        }
    }
}
