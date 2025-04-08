using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Service;

namespace TechShop.Repository
{
    internal interface IInventoryRepository
    {
        Product GetProduct(int id);
        int GetQuantityInStock(int id);
        bool AddToInventory(int productID, int quantity);
        bool RemoveFromInventory(int productId, int quantity);
        bool UpdateStockQuantity(int productId, int newQuantity);
        bool IsProductAvailable(int productID,int quantity);
        decimal GetInventoryValue(int productID);
        List<string> ListLowStockProducts(int threshold);
        List<string> ListOutOfStockProducts();
        List<string> ListAllProducts();
    }
}
