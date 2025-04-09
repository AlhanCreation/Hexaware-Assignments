using OrderManagementsystem.dao;
using OrderManagementsystem.entity;
using System.Linq;

using System;
using OrderManagementsystem.exception;

namespace OrderManagementsystem.main
{
    public class OrderManagement
    {

        public static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();
            bool mainFlag = true;

            while (mainFlag)
            {
                Console.WriteLine("Order Management System Menu:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. Get All Products");
                Console.WriteLine("6. Get Orders For a Specific User");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice(0-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("\nEnter an username: ");
                            string userName = Console.ReadLine();
                            Console.Write("\nEnter a password: ");
                            string password = Console.ReadLine();
                            Console.Write("\nEnter a role(User/Admin): ");
                            string role = Console.ReadLine();
                            User user = new User(userName, password, role);
                            orderProcessor.CreateUser(user);
                        }
                        catch (Exception ex) { Console.WriteLine("\n" + ex.Message); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("\nEnter an username: ");
                            string userName = Console.ReadLine();
                            Console.Write("\nEnter a password: ");
                            string password = Console.ReadLine();
                            Console.Write("\nEnter a role(User/Admin): ");
                            string role = Console.ReadLine();
                            User user = new User(userName, password, role);

                            Console.Write("\nEnter product name: ");
                            string productName = Console.ReadLine();
                            Console.Write("\nEnter description for product: ");
                            string description = Console.ReadLine();
                            Console.Write("\nEnter price of product: ");
                            double price = double.Parse(Console.ReadLine());
                            Console.Write("\nEnter the quantity in stock for the product: ");
                            int quantityInStock = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter type of the product: ");
                            string type = Console.ReadLine();
                            Product product = new Product(productName, description, price, quantityInStock, type);
                            orderProcessor.CreateProduct(user, product);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("\nEnter ID of products in space separated format: ");
                            List<int> productIDs = Console.ReadLine().Split().Select(s => Convert.ToInt32(s)).ToList();
                            List<Product> products = orderProcessor.GetProductsForOrderCreation(productIDs);

                            Console.Write("\nEnter an username: ");
                            string userName = Console.ReadLine();
                            Console.Write("\nEnter a password: ");
                            string password = Console.ReadLine();
                            Console.Write("\nEnter a role(User/Admin): ");
                            string role = Console.ReadLine();
                            User user = new User(userName, password, role);

                            orderProcessor.CreateOrder(user, products);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        break;
                    case "4":
                        try
                        {
                            Console.Write("\nEnter user's ID: ");
                            int userID = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter order ID: ");
                            int orderID = int.Parse(Console.ReadLine());
                            orderProcessor.CancelOrder(userID, orderID);
                        }
                        catch (UserNotFoundException unfex) { Console.WriteLine(unfex.Message); }
                        catch (OrderNotFoundException onfex) { Console.WriteLine(onfex.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "5":
                        try
                        {
                            orderProcessor.GetAllProducts();
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "6":
                        try
                        {
                            Console.Write("\nEnter an username: ");
                            string userName = Console.ReadLine();
                            Console.Write("\nEnter a password: ");
                            string password = Console.ReadLine();
                            Console.Write("\nEnter a role(User/Admin): ");
                            string role = Console.ReadLine();
                            User user = new User(userName, password, role);
                            orderProcessor.GetOrderByUser(user);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        break;
                    case "0":
                        mainFlag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 6.");
                        break;
                }
            }
        }
    }
}