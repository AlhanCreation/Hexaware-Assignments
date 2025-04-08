using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface IOrderRepository
    {
        decimal CalculateTotalAmount(int id);
        Order GetOrderDetails(int id);
        bool UpdateOrderStatus(int id, string status);
        bool CancelOrder(int id);
    }
}
