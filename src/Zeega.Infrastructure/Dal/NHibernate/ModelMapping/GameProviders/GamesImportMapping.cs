using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameProviders;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameProviders {
    class GamesImportMapping : ClassMapping<GamesImport> {
        public GamesImportMapping() {
            Schema(MappingConstants.GAME_PROVIDER_SCHEMA);
            Table("GamesImports");

            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.ImportStartDateTimeUtc, m => {
                m.NotNullable(true);
                m.Access(Accessor.NoSetter);
            });
            Property(x => x.ImportEndDateTimeUtc, m => m.Access(Accessor.NoSetter));
            Property(x => x.EntriesCount, m => m.NotNullable(true));
            Property(x => x.IsProcessed, m => m.NotNullable(true));

            ManyToOne(x => x.GameProvider,
                m => {
                    m.Column("GameProviderId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });
        }
    }
}
