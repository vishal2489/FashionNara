using System.Collections.Generic;
using System.Linq;
using Tailoring.Domain.Providers;
using Tailoring.Models;

namespace Tailoring.Web.Models {
    public class Navigation: INavigation {

        private IHandler<Product> _productHandler;
        private IHandler<ProductSizeType> _productSizeTypeHandler;
        private IHandler<ProductOption> _productOptionHandler;
        public Navigation(IHandler<Product> productHandler,
            IHandler<ProductSizeType> productSizeTypeHandler,
            IHandler<ProductOption> productOptionHandler) {
            _productHandler = productHandler;
            _productOptionHandler = productOptionHandler;
            _productSizeTypeHandler = productSizeTypeHandler;

        }
        private static List<Product> _products = new List<Product>();
        public List<Product> Products {
            get {
                if (_products.Count == 0 || IsProductUpdated) {
                    _products = _productHandler.GetAll().ToList();
                }
                return _products;
            }
        }
        private static List<UserSizeSlection> _productOptions = new List<UserSizeSlection>();
        public List<UserSizeSlection> ProductOptions {
            get {
                if (_productOptions.Count == 0 || IsProductOptionUpdated) {
                    _productOptions = _productSizeTypeHandler.GetAll().OrderBy(x => x.SortOrder).Select(x => new UserSizeSlection() {
                        Description = x.Description,
                        Id = x.Id,
                        ProductId = x.ProductId,
                        SortOrder = x.SortOrder,
                        ProductOptions = _productOptionHandler.GetAll().Where(w => w.ProductSizeTypeId == x.Id).ToList()
                    }).ToList<UserSizeSlection>();

                }
                return _productOptions;
            }
        }

        private static bool _isProductUpdated;
        public bool IsProductUpdated { get { return _isProductUpdated; } set { _isProductUpdated = value; } }

        private static bool isProductOptionUpdated;
        public bool IsProductOptionUpdated {
            get { return isProductOptionUpdated; }
            set { isProductOptionUpdated = value; }
        }
    }
    public interface INavigation {
        List<Product> Products { get; }
        List<UserSizeSlection> ProductOptions { get; }
        bool IsProductUpdated { get; set; }
        bool IsProductOptionUpdated { get; set; }
    }
}