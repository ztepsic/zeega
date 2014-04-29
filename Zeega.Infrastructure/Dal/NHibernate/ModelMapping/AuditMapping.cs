using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping {
    internal class AuditMapping : ComponentMapping<Audit> {
        public AuditMapping() {
            Property(x => x.CreatedOn,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });
            Property(x => x.UpdatedOn, m => m.NotNullable(true));
        }
    }
}
