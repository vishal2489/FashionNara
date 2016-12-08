[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tailoring.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tailoring.Api.App_Start.NinjectWebCommon), "Stop")]

namespace Tailoring.Api.App_Start {
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop() {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly(),
               Assembly
                   .Load("Tailoring.Domain"),
               Assembly
                   .Load("Tailoring.Data"),
               Assembly
                   .Load("Tailoring.DependencyResolver"));
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            } catch {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel) {
            //registerapi(kernel);
            //registerbusiness(kernel);
            //registerdata(kernel);
        }

        //private static void RegisterData(IKernel kernel) {
        //    kernel.Bind<Tailoring.Data.Product.IHandler>().To<Business.Product.Handler>();
        //}

        //private static void RegisterBusiness(IKernel kernel) {
        //    kernel.Bind<Business.Product.IHandler>().To<Business.Product.Handler>();
        //}

        //private static void RegisterApi(IKernel kernel) {

        //}
    }
}
