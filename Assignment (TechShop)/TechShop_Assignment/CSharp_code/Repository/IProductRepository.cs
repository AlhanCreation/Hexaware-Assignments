using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface IProductRepository
    {

        List<Product> GetAllProducts();
        public Product GetProductDetails(int id);
        public bool UpdateProductInfo(int id);
        bool IsProductInStock(int id);
    }
}
