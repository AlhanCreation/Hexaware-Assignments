using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Service
{
    internal interface IProductService
    {
        void GetProductDetails(int id);
        void UpdateProductPrice(int id);
        void IsProductInStock(int id);
        void GetAllProducts();
    }
}
