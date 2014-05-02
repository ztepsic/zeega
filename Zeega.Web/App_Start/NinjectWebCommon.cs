using NHibernate;
using NHibernate.Mapping.ByCode;
using Ninject.Modules;
using Zed.NHibernate;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.ModelMapping;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Zeega.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Zeega.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Zeega.Web.App_Start {
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// Ninject module
    /// </summary>

    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop() {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            } catch {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {
            kernel.Load(new ZeegaModule());
        }

        class ZeegaModule : NinjectModule {
            public override void Load() {
                var modelMapper = new ModelMapper();
                modelMapper.AddMappings();
                NHibernateSessionProvider.Init(cfg => cfg.Configure()
                    .AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities()));

                Bind<ISessionFactory>().ToConstant(NHibernateSessionProvider.SessionFactory);
                Bind<IGameCategoriesRepository>().To<GameCategoriesNhRepository>();
            }
        }
    }
}
