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
    internal class OrderDetailService : IOrderDetailService
    {
        readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailService() { 
            _orderDetailsRepository = new OrderDetailsRepository();
        }

        public void AddDiscount(int id, int discount)
        {
            if(_orderDetailsRepository.AddDiscount(id, discount))
            {
                Console.WriteLine("Successfully reduced the price");
            }
            else
            {
                throw new IncompleteOrderException("The discount has not been given");
            }
        }

        public void CalculateSubtotal(int id)
        {
            decimal total = _orderDetailsRepository.CalculateSubtotal(id);
            if (total > 0)
            {
                Console.WriteLine($"The total amount is {total}");
            }
            else
            {
                throw new InvalidDataException("Invalid Id entered");
            }
        }

        public void GetOrderDetailsById(int id)
        {
            OrderDetails od = _orderDetailsRepository.GetOrderDetailsById(id);
            if( od != null )
            {
                Console.WriteLine(od);
            }
            else
            {
                throw new InvalidDataException("Invalid Id entered");
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            if(_orderDetailsRepository.UpdateQuantity(id, quantity))
            {
                Console.WriteLine($"Orderdetail id {id} updated successfully");
            }
            else
            {
                throw new InvalidDataException("Invalid Id entered");
            }
        }
    }
}
