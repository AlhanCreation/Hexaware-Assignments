using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementsystem.entity
{
    internal class Electronics : Product
    {

        public string Brand { get; set; }
        public int WarrantyPeriod { get; set; }

        public Electronics(string productName, string description, double price, int quantityInStock, string type, string brand, int warrantyPeriod)
            : base(productName, description, price, quantityInStock, type)
        {
            Brand = brand;
            WarrantyPeriod = warrantyPeriod;
        }
        public override string ToString()
        {
            return $"Brand::{Brand}\nWarranty::{WarrantyPeriod}\n";
        }

    }
}
