using Ninject.Modules;
using Tailoring.Domain.Providers;
using Tailoring.Models;

namespace Tailoring.DependencyResolver {
    public class DomainModule: NinjectModule {

        public override void Load() {
            this.Bind<IHandler<Product>>().To<Handler<Product>>().InSingletonScope();
            this.Bind<IHandler<ProductOption>>().To<Handler<ProductOption>>().InSingletonScope();
            this.Bind<IHandler<ProductSizeType>>().To<Handler<ProductSizeType>>().InSingletonScope();
            this.Bind<IHandler<User>>().To<Handler<User>>().InSingletonScope();
            this.Bind<IHandler<RequestOrder>>().To<Handler<RequestOrder>>().InSingletonScope();
        }
    }
}
