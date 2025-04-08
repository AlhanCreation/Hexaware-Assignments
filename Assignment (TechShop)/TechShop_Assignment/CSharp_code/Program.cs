
using TechShop.Model;
using TechShop.Service;

namespace TechShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Task 1: Classes and Their Attributes:
            Task 2: Class Creation:
            Task 3: Encapsulation:
            Task 4: Composition:
            These four tasks have been implemented in the models folder*/

            ICustomerService customerService = new CustomerService();
            IProductService productService = new ProductService();
            IOrderService orderService = new OrderService();
            IOrderDetailService orderDetailService = new OrderDetailService();
            IInventoryService inventoryService = new InventoryService();

            /*Task 5: Exceptions handling 
            Created all the exception classes in the exception folder
            */

            /*
             Task 6: Collections 
            created lists of each class in the repository class
             */

            /*
             Task 7: Database Connectivity
            Connected to database in the utility folder
             */

            //Customer customer = new Customer()
            //{
            //    CustomerId = 30002,
            //    FirstName = "David",
            //    LastName = "Lynch",
            //    Address = "Near Fight club",
            //    Email = "davidlynch@email.com",
            //    Phone = "7893748315"
            //};
            //customerService.CustomerRegistration(customer);


            //customerService.CalculateTotalOrders(1002);
            //customerService.GetAllCustomers();
            //customerService.GetCustomerDetails(1022);

            //customerService.UpdateCustomerInfo(1001, "alhan@gmail.com");


            //productService.GetProductDetails(2003);
            //productService.UpdateProductPrice(2003); // update product price by 10

            //productService.IsProductInStock(2001);


            //orderService.CalculateTotalAmount(30003);
            //orderService.GetOrderDetails(30003);
            //orderService.UpdateOrderStatus(30003, "shipped");
            //orderService.GetOrderDetails(30003);
            //orderService.CancelOrder(30003);


            //orderDetailService.GetOrderDetailsById(4001);

            //orderDetailService.UpdateQuantity(4001, 5);
          //orderDetailService.CalculateSubtotal(4003);
            //orderDetailService.AddDiscount(4002, 19);


            //inventoryService.GetProduct(2);
            //inventoryService.GetQuantityInStock(3);
            //inventoryService.AddToInventory(3, 20);
            //inventoryService.RemoveFromInventory(3, 20);
            //inventoryService.UpdateStockQuantity(8, 10);
            //inventoryService.IsProductAvailable(4, 2);
            //inventoryService.GetInventoryValue(5);
            //inventoryService.ListLowStockProducts(55);
            //inventoryService.ListOutOfStockProducts();
            //inventoryService.ListAllProducts();
        }


    }
    
}
