using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Repository;

namespace TechShop.Service
{
    internal class CustomerService : ICustomerService
    {
       private readonly ICustomerRepository _customerRepository;
         
        public List<Customer> customers;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            customers = _customerRepository.GetAllCustomers();
        }

        

        public void CustomerRegistration(Customer customer)
        {
            if (_customerRepository.AddCustomer(customer))
            {
                Console.WriteLine("Customer successfully registered");
            }
        }

        public void CalculateTotalOrders(int id)
        {
            try
            {
                int count = _customerRepository.CalculateTotalOrders(id);
                Console.WriteLine($"The Total Number of Orders For Customer {id}= {count}");
            }
            catch
            {
                throw new InvalidDataException("Invalid id");
            }
        }

        public void GetAllCustomers()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public void GetCustomerDetails(int id)
        {
            try
            {
                Console.WriteLine(_customerRepository.GetCustomerDetails(id));
            }
            catch
            {
                throw new InvalidDataException("Invalid Customer id");
            }
        }

        public void UpdateCustomerInfo(int id, string email)
        {
            try
            {
                bool updated = _customerRepository.UpdateCustomerInfo(id, email);
                if (updated)
                {
                    Console.WriteLine("Successfully Updated");
                }
            }
            catch
            {
                throw new InvalidDataException("Invalid data, check the customer id and email");
            }
        }


    }
}
