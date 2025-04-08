using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Repository;
using TechShop.Exceptions;
using InvalidDataException = TechShop.Exceptions.InvalidDataException;

namespace TechShop.Service
{
    internal class ProductService : IProductService
    {
        readonly IProductRepository _productRepo;
        public ProductService()
        {
            _productRepo = new ProductRepository();
        }

        public void GetAllProducts()
        {
            List<Product> products = _productRepo.GetAllProducts();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void GetProductDetails(int productId)
        {
            Product product = _productRepo.GetProductDetails(productId);
            if (product != null)
            {
                Console.WriteLine(product);
            }
            else
            {
                throw new InvalidDataException("Invalid Id entered");
            }
        }

        public void IsProductInStock(int id)
        {
            if (_productRepo.IsProductInStock(id))
            {
                Console.WriteLine($"The product with id {id} is in stock");
            }
            else
            {
                throw new InvalidDataException("Invalid id");
            }
        }

        public void UpdateProductPrice(int id)
        {
            bool updatedSuccessfully = _productRepo.UpdateProductInfo(id);
            if(updatedSuccessfully)
            {
                Console.WriteLine("Product price updated successfully by 10%");
            }
            else
            {
                throw new InvalidDataException("Invalid id");
            }
        }

    }
}
