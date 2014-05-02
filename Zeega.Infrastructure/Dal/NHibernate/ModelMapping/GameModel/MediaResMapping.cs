using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping.GameModel {
    class MediaResMapping : ClassMapping<MediaRes> {
        public MediaResMapping() {
            Schema(MappingConstants.GAME_MODEL_SCHEMA);
            Table("MediaResources");

            Id(x => x.Id, m => m.Generator(Generators.Native));

            Property(x => x.Type,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.ThumbSrcUri,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.ThumbSrcWidth,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.ThumbSrcHeight,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.SrcUri,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.SrcHeight,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.SrcWidth,
                m => {
                    m.Access(Accessor.NoSetter);
                    m.NotNullable(true);
                });

            Property(x => x.Sequence, m => m.NotNullable(true));
            Property(x => x.IsActive, m => m.NotNullable(true));
            
        }
    }
}
