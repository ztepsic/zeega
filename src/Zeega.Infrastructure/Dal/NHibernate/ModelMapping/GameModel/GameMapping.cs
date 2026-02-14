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
            Property(x => x.Description);
            Property(x => x.ShortDescription);
            Property(x => x.Instructions);
            Property(x => x.Controls);

            Bag(x => x.Categories,
                m => {
                    m.Schema(MappingConstants.GAME_MODEL_SCHEMA);
                    m.Table("GamesGameCategories");
                    m.Access(Accessor.Field);
                    m.Key(k => {
                        k.Column("GameId");
                        k.NotNullable(true);
                    });
                    m.Cascade(Cascade.All);
                },
                r => r.ManyToMany(m => m.Column("GameCategoryId"))
            );

            Set(x => x.Tags,
                m => {
                    m.Schema(MappingConstants.GAME_MODEL_SCHEMA);
                    m.Table("GamesTags");
                    m.Access(Accessor.Field);
                    m.Key(k => {
                        k.Column("GameId");
                        k.NotNullable(true);
                    });
                    m.Cascade(Cascade.Persist);
                },
                r => r.ManyToMany(m => m.Column("TagId"))
            );


            List(x => x.MediaResources,
                m => {
                    m.Schema(MappingConstants.GAME_MODEL_SCHEMA);
                    m.Table("MediaResources");
                    m.Access(Accessor.Field);
                    m.Key(k => {
                        k.Column("GameId");
                        k.NotNullable(true);
                    });
                    m.Index(i => i.Column("Sequence"));
                    m.Cascade(Cascade.All);
                    m.Inverse(false);
                },
                r => r.OneToMany()
            );

            Component(x => x.GameSrc, c => {
                c.Property(x => x.Width, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.Height, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.SrcType, m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

                c.Property(x => x.SrcUrl, m => {
                    m.Access(Accessor.NoSetter);
                });

                c.Property(x => x.EmbedCode, m => {
                    m.Access(Accessor.NoSetter);
                });

                c.Property(x => x.IsSrcOnline, m => m.NotNullable(true));

                c.Property(x => x.SrcLocalFile);

                c.Component(y => y.DeviceTypeSupport, yc => {
                    yc.Property(x => x.IsDesktopSupported, m => { m.Access(Accessor.NoSetter); });
                    yc.Property(x => x.IsMobileSupported, m => { m.Access(Accessor.NoSetter); });
                });

            });

            ManyToOne(x => x.Provider,
                m => {
                    m.Column("GameProviderId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.ProviderGameUrl, m => m.Column("GameProviderGameUrl"));
            Property(x => x.ProviderPublishDate, m => m.Column("GameProviderPublishDate"));
            Property(x => x.ProviderUpdateDate, m => m.Column("GameProviderUpdateDate"));
            Property(x => x.Author);
            Property(x => x.AuthorUrl);
            Property(x => x.ZipUrl);
            Property(x => x.IsZipDownloaded);

            Component(x => x.ChangeStamp);
        }
    }
}
