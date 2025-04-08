using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        public int CalculateTotalOrders(int id);
        public bool UpdateCustomerInfo(int id, string email);
        public string GetCustomerDetails(int id);

        //add customer
        public bool AddCustomer(Customer customer);
    }
}
