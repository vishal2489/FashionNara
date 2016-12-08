using System.Configuration;
using Ninject.Modules;
using Tailoring.Data;
using Tailoring.Models;

namespace Tailoring.DependencyResolver {
    public class DataModule: NinjectModule {
        public override void Load() {
            this.Bind<IRepository<Product>>().To<MongoDbRepository<Product>>().InSingletonScope();
            this.Bind<IRepository<ProductOption>>().To<MongoDbRepository<ProductOption>>().InSingletonScope();
            this.Bind<IRepository<ProductSizeType>>().To<MongoDbRepository<ProductSizeType>>().InSingletonScope();
            this.Bind<IRepository<User>>().To<MongoDbRepository<User>>().InSingletonScope();
            this.Bind<IRepository<RequestOrder>>().To<MongoDbRepository<RequestOrder>>().InSingletonScope();
        }
    }
}
