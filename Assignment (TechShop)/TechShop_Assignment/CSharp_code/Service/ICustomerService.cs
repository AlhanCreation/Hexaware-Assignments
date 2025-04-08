using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Service
{
    internal interface ICustomerService
    {
        void GetAllCustomers();
        void CustomerRegistration(Customer customer);
        void UpdateCustomerInfo(int id, string email);

        void GetCustomerDetails(int id);

        void CalculateTotalOrders(int id);
    }
}
