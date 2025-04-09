using System;
using OrderManagementsystem.entity;
using System.Data.SqlClient;
using OrderManagementsystem.exception;
using OrderManagementSystem.util;

namespace OrderManagementsystem.dao

{
    public class OrderProcessor : IOrderManagementRepository
    {
        SqlCommand cmd = null!;
        SqlDataReader dr = null!;
        public void CreateOrder(User user, List<Product> products)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string qry = $"SELECT * FROM Users where username = \'{user.Username}\' and password = \'{user.Password}\'";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    CreateUser(user);
                }
                dr.Close();
                foreach (Product product in products)
                {
                    qry = $"INSERT INTO Orders values ((SELECT userID from Users where username = \'{user.Username}\' AND password = \'{user.Password}\'), {product.ProductId}, \'{DateTime.Now}\', \'Processing\')";
                    cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Order created successfully");

        }

        public void CancelOrder(int userID, int orderID)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string qry = $"SELECT * FROM Users where UserID = {userID}";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    throw new UserNotFoundException("Could not find user!");
                }
                dr.Close();
                qry = $"SELECT * FROM Orders where OrderID = {orderID}";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    throw new OrderNotFoundException("Could not find order!");
                }
                dr.Close();
                qry = $"UPDATE Orders SET status = \'Canceled\' WHERE OrderID = {orderID}";
                cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successfully canceled the order!");
            }
        }

        public void CreateProduct(User user, Product product)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                if (user.Role.ToLower() != "admin")
                {
                    throw new Exception("Cannot process this request as the user is not an admin!");
                }
                string qry = $"SELECT * FROM Users where UserID = {user.UserId}";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                if (!dr.HasRows && (dr.HasRows && dr.GetValue(3).ToString().ToLower() != "admin"))
                {
                    CreateUser(user);
                }
                dr.Close();
                qry = $"INSERT INTO Products values (\'{product.ProductName}\', \'{product.Description}\', {product.Price}, {product.QuantityInStock}, \'{product.Type}\')";
                cmd = new SqlCommand(qry, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) { Console.WriteLine("Successfully added product to the database!"); }
                else Console.WriteLine("Could not add product to the database!");
            }
        }

        public void CreateUser(User user)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string qry = $"INSERT INTO Users values (\'{user.Username}\', \'{user.Password}\', \'{user.Role}\')";
                cmd = new SqlCommand(qry, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) { Console.WriteLine("Successfully created user!"); }
                else Console.WriteLine("Could not create user!");
            }
        }

        public void GetAllProducts()
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string qry = "SELECT * FROM Products";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                Console.WriteLine("Following is the list of all available products: ");
                while (dr.Read())
                {
                    var data = Enumerable.Range(0, dr.FieldCount).Select(dr.GetValue).ToList();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine($"{columns[i]} : {data[i]}");
                    }
                    Console.WriteLine("--------------------------------------------------------------------");
                }
            }
        }

        public void GetOrderByUser(User user)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {

                string qry = $"SELECT * FROM Orders WHERE UserID = (SELECT UserID from Users where username = \'{user.Username}\' and password = \'{user.Password}\')";
                cmd = new SqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                if (!dr.HasRows) throw new OrderNotFoundException("Could not find any orders for this user!");
                Console.WriteLine("Following are the orders by the user with ID " + user.UserId + ": ");
                while (dr.Read())
                {
                    var data = Enumerable.Range(0, dr.FieldCount).Select(dr.GetValue).ToList();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine($"{columns[i]} : {data[i]}");
                    }
                    Console.WriteLine(new String('-', 50));
                }
            }
        }
        
        public List<Product> GetProductsForOrderCreation(List<int> productIDs)
        {
            List<Product> products = new List<Product>();
            using(SqlConnection conn = DBUtil.GetDBConn())
            {
                foreach(var ID in productIDs)
                {
                    string qry = $"SELECT * FROM Products WHERE ProductID = {ID}";
                    cmd = new SqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        dr.Read();
                        Product product = new Product((int)dr.GetValue(0), (string)dr.GetValue(1), (string)dr.GetValue(2), (double)dr.GetValue(3), (int)dr.GetValue(4), (string)dr.GetValue(5));
                        products.Add(product);
                        dr.Close();
                    }
                }
                return products;
            }

        }
    }
}

