using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Service
{
    internal interface IOrderService
    {
        void CalculateTotalAmount(int id);
        void GetOrderDetails(int id);
        void UpdateOrderStatus(int id, string status);
        void CancelOrder(int id);
    }
}
