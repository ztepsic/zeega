using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class GameProviderMapping : ClassMapping<GameProvider> {
        public GameProviderMapping() {
            Schema(MappingConstants.GAME_MODEL_SCHEMA);
            Table("GameProviders");

            Id(x => x.Id, m => m.Generator(Generators.Native));

            Property(x => x.Name,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
            });

            Property(x => x.OfficialUrl,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
            });

            Property(x => x.PublisherUrl);
            Property(x => x.HasPublisherApi);
            Property(x => x.GamesCatalogUrl);
            Property(x => x.HasXmlFeed);
            Property(x => x.HasJsonFeed);
            Property(x => x.IsActive);
            Component(x => x.ChangeStamp);

        }
    }
}
