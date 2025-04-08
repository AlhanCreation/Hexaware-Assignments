using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;
using TechShop.Model;
using TechShop.Repository;
using InvalidDataException = TechShop.Exceptions.InvalidDataException;

namespace TechShop.Service
{
    internal class InventoryService : IInventoryService
    {
        readonly IInventoryRepository inventoryRepository;
        public InventoryService() { 
            inventoryRepository = new InventoryRepository();
        }
        public void AddToInventory(int productID, int quantity)
        {
            try
            {
                if (inventoryRepository.AddToInventory(productID, quantity))
                {
                    Console.WriteLine("Quantity Added Successfully");
                }
            }
            catch
            {
                throw new InvalidDataException("Invalid product id entered");
            }
            
        }

        public void GetInventoryValue(int productID)
        {
            decimal value = inventoryRepository.GetInventoryValue(productID);
            if (value > 0)
            {
                Console.WriteLine($"The total value of the product {productID} is {value}");
            }
            else
            {
                throw new InvalidDataException("Invalid Product Id entered");
            }
        }

        public void GetProduct(int id)
        {
            Product product = inventoryRepository.GetProduct(id);
            if(product == null)
            {
                throw new InvalidDataException("Invalid Product Id entered");
            }
            else
            {
                Console.WriteLine(product);
            }
            
        }

        public void GetQuantityInStock(int id)
        {
            int quantity = inventoryRepository.GetQuantityInStock(id);
            if (quantity == 0)
            {
                throw new InvalidDataException("Invalid Product Id entered");
            }
            else
            {
                Console.WriteLine(quantity);
            }
        }

        public void IsProductAvailable(int productID, int quantity)
        {
            if (inventoryRepository.IsProductAvailable(productID, quantity))
            {
                Console.WriteLine($"The product {productID} and the quantity {quantity} you asked is available.");
            }
            else
            {
                throw new InsufficientStockException($"The product {productID} is not availabe at your selected quantity {quantity}");
            }
        }

        public void ListAllProducts()
        {
            List<string> result = inventoryRepository.ListAllProducts();
            if(result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                throw new InsufficientStockException("No products available");
            }
            
        }

        public void ListLowStockProducts(int threshold)
        {
            List<string> result = inventoryRepository.ListLowStockProducts(threshold);
            if (result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                throw new InsufficientStockException("No products available");
            }
        }

        public void ListOutOfStockProducts()
        {
            List<string> result = inventoryRepository.ListOutOfStockProducts();
            if (result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                throw new InsufficientStockException("No products available");
            }
        }

        public void RemoveFromInventory(int productId, int quantity)
        {
            if(inventoryRepository.RemoveFromInventory(productId, quantity))
            {
                Console.WriteLine("Command succesfully implemented");
            }
            else
            {
                throw new InvalidDataException("Invalid Product Id entered");
            }
        }

        public void UpdateStockQuantity(int productId, int newQuantity)
        {
            if (inventoryRepository.UpdateStockQuantity(productId, newQuantity))
            {
                Console.WriteLine("Updated successfully");
            }
            else
            {
                throw new InvalidDataException("Invalid Product Id entered");
            }
        }
    }
}
