using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Inventory(int inventoryID,int productID,int quantity,DateTime lastStockUpdate) 
        { 
            InventoryID = inventoryID;
            ProductID = productID;
            QuantityInStock = quantity;
            LastStockUpdate = lastStockUpdate;
        }
        public override string ToString()
        {
            return $"InventoryID::{InventoryID}\nProductID::{ProductID}\nQuantityInStock::{QuantityInStock}\nLastStockUpdate::{LastStockUpdate}";
        }
    }
}
