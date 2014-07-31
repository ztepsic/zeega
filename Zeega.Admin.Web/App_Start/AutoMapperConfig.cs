﻿using AutoMapper;
using Zeega.Admin.Web.Models.Game;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web {
    /// <summary>
    /// Auto mapper config class
    /// </summary>
    public static class AutoMapperConfig {

        /// <summary>
        /// Configures autom mapper with mappings
        /// </summary>
        public static void Configure() {
            Mapper.CreateMap<GameProviderModel, GameProvider>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            Mapper.CreateMap<GameProvider, GameProviderModel>();
        }
    }
}