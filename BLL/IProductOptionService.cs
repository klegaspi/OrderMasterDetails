using Models;
//using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductOptionService
    {
        IEnumerable<ProductOption> GetAllProductOptions();

        IEnumerable<ProductOption> GetAllProductOptionsByProductID(int productID);

        IEnumerable<ProductOption> GetProductsOptionsByProductName(string productName);

        IEnumerable<ProductOption> GetProductsOptionsByName(string name);

        void AddProductOption(ProductOption entity);

        void EditProductOption(ProductOption entity);

        void DeleteProductOption(int productOptionID);

        void DeleteProductOption(int productOptionID, int productID);
    }
}
