using System;
// No changes needed for the Product class as it is already correctly implemented.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product() { }
        public Product(int productID, string productName, string description, decimal price)
        {
            ProductID = productID;
            ProductName = productName;
            Description = description;
            Price = price;

        }
        public override string ToString()
        {
            return $"ProductID::{ProductID}\nProductName::{ProductName}\nDescription::{Description}\nPrice::{Price}";
        }
    }

    
}
