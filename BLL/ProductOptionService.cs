using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IRepository<ProductOption> _productOptionRepository = null;

        public ProductOptionService(IRepository<ProductOption> productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public IEnumerable<Models.ProductOption> GetAllProductOptions()
        {
            return _productOptionRepository.GetAll();
        }

        public IEnumerable<Models.ProductOption> GetAllProductOptionsByProductID(int productID)
        {
            return _productOptionRepository.GetBy(m => m.ProductID == productID);
        }

        public IEnumerable<Models.ProductOption> GetProductsOptionsByProductName(string productName)
        {
            return _productOptionRepository.GetBy(m => m.Name == productName);
        }

        public IEnumerable<Models.ProductOption> GetProductsOptionsByName(string name)
        {
            return _productOptionRepository.GetBy(m => m.Name == name);
        }

        public void AddProductOption(ProductOption entity)
        {
            _productOptionRepository.Add(entity);
        }

        public void EditProductOption(ProductOption entity)
        {
            _productOptionRepository.Edit(entity);
        }

        public void DeleteProductOption(int productoptionid)
        {
            var productoption = this._productOptionRepository.GetBy(m => m.ProductOptionID == productoptionid);

            if (productoption != null)
                _productOptionRepository.DeleteRange(productoption);
        }

        public void DeleteProductOption(int productOptionID, int productID)
        {
            var productOption = _productOptionRepository.GetBy(m => m.ProductOptionID == productOptionID && m.ProductID == productID).SingleOrDefault();

            if (productOption != null)
                _productOptionRepository.Delete(productOption);
        }
    }
}
