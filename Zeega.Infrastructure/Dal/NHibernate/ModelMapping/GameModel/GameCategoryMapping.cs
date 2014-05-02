﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class GameCategoryMapping : ClassMapping<GameCategory> {
        public GameCategoryMapping() {
            Table("GameCategories");
            Schema("Game");

            Id(x => x.Id, m => m.Generator(Generators.Native));

            ManyToOne(x => x.AppTenant,
                m => {
                    m.Column("AppTenantId");
                    m.Access(Accessor.NoSetter);
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

            Property(x => x.Sequence, m => m.NotNullable(true));
            Property(x => x.Description);
            Property(x => x.ShortDescription);
            Property(x => x.Keywords);

        }
    }
}
