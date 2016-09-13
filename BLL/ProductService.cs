using Models;
using Repository;
//using Models;
//using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository = null;

        public ProductService()
        {
        }
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return _productRepository.GetBy(m => m.Name == name);
        }

        public void AddProduct(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void EditProduct(Product entity)
        {
            _productRepository.Edit(entity);
        }

        public void DeleteProduct(int productID)
        {
            Product product = _productRepository.GetBy(m => m.ProductID == productID).SingleOrDefault();

            if (product != null)
                _productRepository.Delete(product);
        }        
    }
}
