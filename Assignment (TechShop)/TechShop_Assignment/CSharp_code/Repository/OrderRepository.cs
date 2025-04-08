using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public OrderRepository()
        {
            connectionString = DBConnectionUtility.GetConnectedString();
            cmd = new SqlCommand();
        }

        public decimal CalculateTotalAmount(int id)
        {
            decimal totalAmount = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select TotalAmount from orders where OrderID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    totalAmount = (decimal)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return totalAmount;
        }

        public bool CancelOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "delete from orders where orderid=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    if (rowsEffected > 0)
                    return true;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public Order GetOrderDetails(int id)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select * from orders where OrderID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderID = (int)reader["OrderID"];
                        order.CustomerID = (int)reader["CustomerID"];
                        order.OrderDate = (DateTime)reader["OrderDate"];
                        order.TotalAmount = (decimal)reader["TotalAmount"];
                        order.Status = (string)reader["Status"];
                        return order;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool UpdateOrderStatus(int id, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "update orders set status = @status where orderid=@id";
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}
