using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByName(string name);

        void AddProduct(Product entity);

        void EditProduct(Product entity);

        void DeleteProduct(int productID);
    }
}
