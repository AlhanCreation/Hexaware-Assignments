using OrderManagementsystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementsystem.dao
{

    public interface IOrderManagementRepository
    {
        public void CreateOrder(User user, List<Product> products);
        public void CancelOrder(int userId, int orderId);
        public void CreateProduct(User user, Product product);
        public void CreateUser(User user);
        public void GetAllProducts();
        public void GetOrderByUser(User user);
    }
}
