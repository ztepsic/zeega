using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class GameInstanceMapping : ClassMapping<GameInstance> {
        public GameInstanceMapping() {
            Schema(MappingConstants.GAME_MODEL_SCHEMA);
            Table("GameInstances");

            Id(x => x.Id, m => m.Generator(Generators.Native));

            ManyToOne(x => x.AppTenant,
                m => {
                    m.Column("AppTenantId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            ManyToOne<Game>("game",
                m => {
                    m.Column("GameId");
                    m.NotNullable(true);
                });

            Property(x => x.Name,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.Slug,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            ManyToOne(x => x.PrimaryInstanceCategory, m => {
                    m.Column("PrimaryGameCategoryId");
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Bag(x => x.SecondaryCategories,
                m => {
                    m.Schema(MappingConstants.GAME_MODEL_SCHEMA);
                    m.Table("SecondaryGameInstCategories");
                    m.Access(Accessor.NoSetter);
                    m.Key(k => {
                        k.Column("GameInstanceId");
                        k.NotNullable(true);
                    });
                },
                r => r.ManyToMany(m => m.Column("GameCategoryId"))
            );

            Property(x => x.Description);
            Property(x => x.ShortDescription);
            Property(x => x.Instructions);
            Property(x => x.Controls);

            Bag(x => x.Tags,
                m => {
                    m.Schema(MappingConstants.GAME_MODEL_SCHEMA);
                    m.Table("GameInstanceTags");
                    m.Access(Accessor.NoSetter);
                    m.Key(k => {
                        k.Column("GameInstanceId");
                        k.NotNullable(true);
                    });
                },
                r => r.ManyToMany(m => m.Column("TagId"))
            );

            Property(x => x.IsPublished);
            Component(x => x.ChangeStamp);
           
        }
    }
}
