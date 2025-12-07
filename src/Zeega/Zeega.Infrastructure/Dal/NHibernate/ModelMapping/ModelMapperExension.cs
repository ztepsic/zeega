using NHibernate.Mapping.ByCode;

namespace Zeega.Infrastructure.Dal.NHibernate.ModelMapping {
    /// <summary>
    /// NHibernate model mapper exension
    /// </summary>
    public static class ModelMapperExension {
        /// <summary>
        /// Adds Zeeg Domain mappings
        /// </summary>
        /// <returns>Mapping types</returns>
        public static void AddMappings(this ModelMapper modelMapper) {
            //modelMapper.AddMappings(typeof(AppTenantMapping).Assembly.GetExportedTypes());

            var namespaceStr = typeof(AppTenantMapping).Namespace;
            var types = from t in typeof(AppTenantMapping).Assembly.GetTypes()
                        where t.Namespace != null && t.Namespace.Contains(namespaceStr)
                        select t;
            modelMapper.AddMappings(types);

        }
    }
}
