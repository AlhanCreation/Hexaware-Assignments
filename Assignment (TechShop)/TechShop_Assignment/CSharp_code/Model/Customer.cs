using System;
// No changes needed for the Customer class as it is already correctly implemented.
namespace TechShop.Model
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public Customer() { }

        public Customer(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerId = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {   Console.WriteLine("Customer Details\n");
            return $"CustomerID:: {CustomerId}\n" +
                   $"FirstName::{FirstName}\n" +
                   $"LastName::{LastName}\n" +
                   $"Email::{Email}\n" +
                   $"Phone::{Phone}\n" +
                   $"Address::{Address}\n";
        }
    }
}
