using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        private Order order;
        private Product product;

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public OrderDetails()
        {

        }

       
        public OrderDetails(int orderDetailID, int orderID, int productID, int quantity,decimal amount)
        {
            OrderDetailID = orderDetailID;
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"OrderDetailID::{OrderDetailID}\nOrderID::{OrderID}\nProductID::{ProductID}\nQuantity::{Quantity}\nAmount::{Amount}\n";
        }
    }
}
