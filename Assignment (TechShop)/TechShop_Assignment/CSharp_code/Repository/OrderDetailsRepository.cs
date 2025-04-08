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
    internal class OrderDetailsRepository : IOrderDetailsRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public OrderDetailsRepository()
        {
            connectionString = DBConnectionUtility.GetConnectedString();
            cmd = new SqlCommand();
        }
        public bool AddDiscount(int id, int discount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "update orderdetails set amount=amount-(amount*@discount/100) where orderdetailid=@id";
                cmd.Parameters.AddWithValue("@discount", discount);
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

        public decimal CalculateSubtotal(int id)
        {
            decimal total = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select amount*quantity from orderdetails where orderdetailid=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                try
                {
                    total = (decimal)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }
        public OrderDetails GetOrderDetailsById(int id)
        {
            OrderDetails orderDetails = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select * from orderdetails where orderdetailid=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    orderDetails = new OrderDetails();
                    orderDetails.OrderDetailID = (int)reader["OrderDetailID"];
                    orderDetails.ProductID = (int)reader["ProductID"];
                    orderDetails.OrderID = (int)reader["OrderID"];
                    orderDetails.Quantity = (int)reader["Quantity"];
                    
                   


                }
            }
            return orderDetails;
        }

        public bool UpdateQuantity(int id, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "update orderdetails set quantity = @quanty where orderdetailid=@id";
                cmd.Parameters.AddWithValue("@quanty", quantity);
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
