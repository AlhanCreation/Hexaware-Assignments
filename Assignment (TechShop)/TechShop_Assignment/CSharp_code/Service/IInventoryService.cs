using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Service
{
    internal interface IInventoryService
    {
        void GetProduct(int id);
        void GetQuantityInStock(int id);
        void AddToInventory(int productID, int quantity);
        void RemoveFromInventory(int productId, int quantity);
        void UpdateStockQuantity(int productId, int newQuantity);
        void IsProductAvailable(int productID, int quantity);
        void GetInventoryValue(int productID);
        void ListLowStockProducts(int threshold);
        void ListOutOfStockProducts();
        void ListAllProducts();
    }
}
