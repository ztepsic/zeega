using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping {
    class LanguageCodeMapping : ComponentMapping<LanguageCode> {
        public LanguageCodeMapping() {
            Property(x => x.Value,
                   m => {
                       m.Column("LanguageCode");
                        m.Access(Accessor.NoSetter);
                        m.NotNullable(true);
                   });
        }
    }
}
