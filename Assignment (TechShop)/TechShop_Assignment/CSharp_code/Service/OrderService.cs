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
    internal class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepo;
        public OrderService()
        {
            _orderRepo = new OrderRepository();
        }

        public void CalculateTotalAmount(int id)
        {
            decimal totalAmount = _orderRepo.CalculateTotalAmount(id);
            if (totalAmount > -1)
            {
                Console.WriteLine($"The total amount of order{id} = {totalAmount} ");
            }
            else
            {
                throw new IncompleteOrderException("Calculation of total amount has been unsuccessful");
            }
        }

        public void CancelOrder(int id)
        {
            if(_orderRepo.CancelOrder(id))
            {
                Console.WriteLine($"The order with the order id {id} has been cancelled");
            }else { throw new InvalidDataException("Invalid order Id entered"); }
        }

        public void GetOrderDetails(int id)
        {
            Order o = _orderRepo.GetOrderDetails(id);
            if(o != null)
            {
                Console.WriteLine(o);
            }else { throw new InvalidDataException("Invalid Id entered"); }
        }

        public void UpdateOrderStatus(int id, string status)
        {
            if(_orderRepo.UpdateOrderStatus(id, status))
            {
                Console.WriteLine($"The order Status with {id} has been Updated");
            }
            else { throw new InvalidDataException("Invalid Id entered"); }
        
        }
    }
}
