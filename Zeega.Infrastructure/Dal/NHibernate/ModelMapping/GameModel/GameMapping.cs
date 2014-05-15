using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class GameMapping : ClassMapping<Game> {
        public GameMapping() {
            Schema(MappingConstants.GAME_MODEL_SCHEMA);
            Table("Games");

            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Name, m => m.NotNullable(true));
            Property(x => x.ExternalId);
            Property(x => x.Categories);
            Property(x => x.Description);
            Property(x => x.ShortDescription);
            Property(x => x.Instructions);
            Property(x => x.Controls);
            Property(x => x.Tags);

            List(x => x.MediaResources,
                m => {
                    m.Access(Accessor.Field);
                    m.Key(k => {
                        k.Column("GameId");
                        k.NotNullable(true);
                    });
                    m.Index(i => i.Column("Sequence"));
                },
                r => r.OneToMany());

            Component(x => x.GameSrc, c => {
                c.Property(x => x.Width, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.Height, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.SrcUri, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.SrcType, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.IsSrcOnline, m => m.NotNullable(true));

            });

            ManyToOne(x => x.Provider,
                m => {
                    m.Column("GameProviderId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.ProviderGameUrl);
            Property(x => x.Author);
            Property(x => x.AuthorUrl);
            Property(x => x.ZipUrl);
            Property(x => x.IsZipDownloaded);

            Component(x => x.Audit);
        }
    }
}
