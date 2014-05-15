using AutoMapper;
using Zeega.BackOffice.Web.Models;
using Zeega.Domain.GameModel;

namespace Zeega.BackOffice.Web.App_Start {
    /// <summary>
    /// Auto mapper config class
    /// </summary>
    public static class AutoMapperConfig {

        /// <summary>
        /// Configures autom mapper with mappings
        /// </summary>
        public static void Configure() {
            Mapper.CreateMap<Game, GameViewModel>();
        }
    }
}