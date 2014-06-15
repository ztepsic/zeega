using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class GameCategoryMapping : ClassMapping<GameCategory> {

        public GameCategoryMapping() {
            Schema(MappingConstants.GAME_MODEL_SCHEMA);
            Table("GameCategories");

            Id(x => x.Id, m => m.Generator(Generators.Native));

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
            
        }

    }
}
