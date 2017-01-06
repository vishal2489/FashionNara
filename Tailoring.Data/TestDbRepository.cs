using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using Tailoring.Models;

namespace Tailoring.Data {
    public class TestDbRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase {
        public void Delete(ObjectId id) {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity) {
            throw new NotImplementedException();
        }

        public TEntity Get(ObjectId id) {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll() {
            if(typeof(TEntity) == typeof(Product)) {
                return _products.Count>0? (IEnumerable<TEntity>)_products : (IEnumerable<TEntity>)GetProducts();
            } else if(typeof(TEntity) == typeof(ProductOption)) {
                return _productOptions.Count > 0 ? (IEnumerable<TEntity>)_productOptions : (IEnumerable<TEntity>)GetProductOptions();
            } else if(typeof(TEntity) == typeof(RequestOrder)) {
              return  _requestOrders.Count > 0 ? (IEnumerable<TEntity>)_requestOrders : (IEnumerable<TEntity>)GetRequestOrders();
            }
            else {
                return _productSizeTypes.Count > 0 ? (IEnumerable<TEntity>)_productSizeTypes : (IEnumerable<TEntity>)GetProductSizeType();
            }
        }

        public void Insert(TEntity entity) {
            if(typeof(TEntity) == typeof(Product)) {
                Product p = entity as Product;
                _products.Add(p);
            } else if(typeof(TEntity) == typeof(ProductOption)) {
                ProductOption p = entity as ProductOption;
                _productOptions.Add(p);
            } else if(typeof(TEntity) == typeof(RequestOrder)) {
                RequestOrder p = entity as RequestOrder;
                _requestOrders.Add(p);
            }
            else {
                ProductSizeType p = entity as ProductSizeType;
                _productSizeTypes.Add(p);
            }
        }

        public TEntity Save(TEntity entity) {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate) {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity) {
            throw new NotImplementedException();
        }


        private static List<Product> _products = new List<Product>();
        private List<Product> GetProducts() {
            _products.Add(new Product() {
                Abbreviation = "KRT",
                Description = "Kurta",
                FromAmout = 699,
                Id = new ObjectId("500c20efc78bb07bfbb69eb1"),
                ImageUrl = @"~/Resources/Images/Kurta_home.jpg",
                IsAcive = true,
                ProductCategory = ProductCategory.Women,
                ToAmout = 2500
            });
            return _products;
        }
        private static List<ProductSizeType> _productSizeTypes = new List<ProductSizeType>();
        private List<ProductSizeType> GetProductSizeType() {
            _productSizeTypes.Add(new ProductSizeType() {
                Description = "Front",
                Id = new ObjectId("500c2118c78bb07bfbb69eb1"),
                ProductId = new ObjectId("500c20efc78bb07bfbb69eb1"),
                SortOrder = 1
            });
            _productSizeTypes.Add(new ProductSizeType() {
                Description = "Back",
                Id = new ObjectId("500c2118c78bb07bfbb69eb2"),
                ProductId = new ObjectId("500c20efc78bb07bfbb69eb1"),
                SortOrder = 2
            });
            _productSizeTypes.Add(new ProductSizeType() {
                Description = "Sleeve",
                Id = new ObjectId("500c2118c78bb07bfbb69eb3"),
                ProductId = new ObjectId("500c20efc78bb07bfbb69eb1"),
                SortOrder = 3
            });
            _productSizeTypes.Add(new ProductSizeType() {
                Description = "Hemline",
                Id = new ObjectId("500c2118c78bb07bfbb69eb4"),
                ProductId = new ObjectId("500c20efc78bb07bfbb69eb1"),
                SortOrder = 4
            });
            _productSizeTypes.Add(new ProductSizeType() {
                Description = "AddOn",
                Id = new ObjectId("500c2118c78bb07bfbb69eb5"),
                ProductId = new ObjectId("500c20efc78bb07bfbb69eb1"),
                SortOrder = 5
            });
            return _productSizeTypes;
        }
        private static List<ProductOption> _productOptions = new List<ProductOption>();
        private List<ProductOption> GetProductOptions() {
            _productOptions.Add(new ProductOption() {
                Amount = 0,
                Description = "Round V Neck",
                Group = "General",
                Id = new ObjectId("500c227ac78bb07bfbb69eb1"),
                ImageUrl = @"../Resources/Images/UTC1.png",
                IsActive = true,
                IsDefaultWithProduct = true,
                IsFree = true,
                OptionType = "Front",
                ProductSizeTypeId = new ObjectId("500c2118c78bb07bfbb69eb1")
            });
            _productOptions.Add(new ProductOption() {
                Amount = 0,
                Description = "Close Back",
                Group = "General",
                Id = new ObjectId("500c227ac78bb07bfbb69eb2"),
                ImageUrl = @"../Resources/Images/UTC103.png",
                IsActive = true,
                IsDefaultWithProduct = true,
                IsFree = true,
                OptionType = "Back",
                ProductSizeTypeId = new ObjectId("500c2118c78bb07bfbb69eb2")
            });
            _productOptions.Add(new ProductOption() {
                Amount = 0,
                Description = "Cap Sleeve",
                Group = "General",
                Id = new ObjectId("500c227ac78bb07bfbb69eb3"),
                ImageUrl = @"../Resources/Images/CapSleeve_Sleeve.png",
                IsActive = true,
                IsDefaultWithProduct = true,
                IsFree = true,
                OptionType = "Sleeve",
                ProductSizeTypeId = new ObjectId("500c2118c78bb07bfbb69eb3")
            });
            _productOptions.Add(new ProductOption() {
                Amount = 0,
                Description = "Mid Thigh",
                Group = "General",
                Id = new ObjectId("500c227ac78bb07bfbb69eb4"),
                ImageUrl = @"../Resources/Images/MidThighLength_Hemline.png",
                IsActive = true,
                IsDefaultWithProduct = true,
                IsFree = true,
                OptionType = "Hemline",
                ProductSizeTypeId = new ObjectId("500c2118c78bb07bfbb69eb4")
            });
            _productOptions.Add(new ProductOption() {
                Amount = 0,
                Description = "Top Lining",
                Group = "Add-ons",
                Id = new ObjectId("500c227ac78bb07bfbb69eb5"),
                ImageUrl = @"../Resources/Images/TopLining_AddOn.png",
                IsActive = true,
                IsDefaultWithProduct = true,
                IsFree = true,
                OptionType = "Add-ons",
                ProductSizeTypeId = new ObjectId("500c2118c78bb07bfbb69eb5")
            });

            return _productOptions;
        }

        private static List<RequestOrder> _requestOrders = new List<RequestOrder>();
        private  List<RequestOrder> GetRequestOrders() {
            return _requestOrders;
        }
    }
}
