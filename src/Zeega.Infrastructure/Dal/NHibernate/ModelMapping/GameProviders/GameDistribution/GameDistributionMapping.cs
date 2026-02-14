using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameProviders.GameDistributionGame;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameProviders.GameDistribution {
    class GameDistributionGameMapping : ClassMapping<GameDistributionGame> {
        public GameDistributionGameMapping() {
            Schema(MappingConstants.GAME_PROVIDER_SCHEMA);
            Table("GameDistributionGames");

            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.ExternalId, m => {
                m.Column("ExternalId");
                m.NotNullable(true);
                m.Access(Accessor.NoSetter);
            });
            Property(x => x.Title, m => m.Access(Accessor.NoSetter));
            Property(x => x.Description);
            Property(x => x.CatTitle);
            Property(x => x.Tags);
            Property(x => x.ActivedDate);
            Property(x => x.AddedDate, m => m.NotNullable(true));
            Property(x => x.GameAddedDate);
            Property(x => x.ExternalThumbUrl);
            Property(x => x.Thumbnail);
            Property(x => x.ExternalUrl);
            Property(x => x.ExternalSrcUrl);
            Property(x => x.LinkUrl);
            Property(x => x.GameType);
            Property(x => x.Width);
            Property(x => x.Height);
            Property(x => x.GameMd5);

            ManyToOne(x => x.GamesImport,
                m => {
                    m.Column("GamesImportId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                    m.Cascade(Cascade.Persist);
                });

        }
    }
}
