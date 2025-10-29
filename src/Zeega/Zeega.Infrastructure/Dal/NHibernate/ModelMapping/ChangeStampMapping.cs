using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateLib = NHibernate;
using Zeega.Domain;


namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping {
    internal class ChangeStampMapping : ComponentMapping<ChangeStamp> {
        public ChangeStampMapping() {
            Property(x => x.CreatedOn,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                    m.Type(new NHibernateLib.Type.UtcDateTimeType());
                });
            Property(x => x.UpdatedOn,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                    m.Type(new NHibernateLib.Type.UtcDateTimeType());
                });
        }
    }
}
