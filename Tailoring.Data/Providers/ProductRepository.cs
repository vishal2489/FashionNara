using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Tailoring.Data.Providers;
using Tailoring.Models;

namespace Tailoring.Data.Repository {
    public class ProductRepository: IProductRepository {

        //private string _connectionName;
        //public ProductRepository(string connectionName) {
        //    _connectionName = connectionName;
        //}
        private DbProvider _db = new DbProvider();
        public void CreateProduct(Product product) {
            //using (TailoringContext context = new TailoringContext()) {
            //    //  context.Database.Create();
            //    IList<Product> blogposts = context.Products.ToList<Product>();
            //    var products = from product in context.Products
            //                   select product.ToDomainProduct();
            //    return products.ToList<Models.Product>();
            //}

            _db.CrateProduct(product);
            
        }

        public IEnumerable<Product> GetProducts() {
           _db.g
        }
    }

    public interface IProductRepository {
        void CreateProduct(Product product);
        IEnumerable<Product> GetProducts();
    }
}