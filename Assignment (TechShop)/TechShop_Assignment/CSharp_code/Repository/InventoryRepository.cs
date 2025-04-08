using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class InventoryRepository : IInventoryRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public InventoryRepository()
        {
            connectionString = DBConnectionUtility.GetConnectedString();
            cmd = new SqlCommand();
        }
        public bool AddToInventory(int productId,int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.CommandText = "update inventory set QuantityInStock = QuantityInStock+@quantity where ProductID=@id";
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Connection = conn;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public decimal GetInventoryValue(int productID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.CommandText = "select (products.price*inventory.quantityinstock) from inventory join products on products.productid=inventory.productid where inventory.productid=@id";
                cmd.Parameters.AddWithValue("@id", productID);
                cmd.Connection = conn;
                decimal price;
                try
                {
                    price = (decimal)cmd.ExecuteScalar();
                    return price;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return -1;
        }

        public Product GetProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select Products.ProductID, Products.ProductName, Products.description, products.price from products join inventory on products.productid=inventory.productid where inventory.productid=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = (int)reader["ProductID"];
                    product.ProductName = (string)reader["ProductName"];
                    product.Description = (string)reader["Description"];
                    product.Price = (decimal)reader["Price"];
                    return product;
                }
            }
            return null;
        }

        public int GetQuantityInStock(int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select QuantityInStock from Inventory where ProductID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                int quantity;
                try
                {
                    quantity = (int)cmd.ExecuteScalar();
                    return quantity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return 0;
        }

        public bool IsProductAvailable(int productID, int quantity)
        {
            using( SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open ();
                cmd.CommandText = "select quantityinstock from inventory where productid=@id";
                cmd.Parameters.AddWithValue("@id", productID);
                cmd.Connection = connection;
                int productQuantity;
                try
                {
                    productQuantity = (int)cmd.ExecuteScalar();
                    return productQuantity>=quantity;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return false;
        }

        public List<string> ListAllProducts()
        {
            List<string> result = new List<string>();
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select products.ProductName from inventory join products on products.productid=inventory.productid";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;

        }

        public List<string> ListLowStockProducts(int threshold)
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select products.ProductName from inventory join products on products.productid=inventory.productid where inventory.quantityinstock<@threshold";
                cmd.Parameters.AddWithValue("@threshold", threshold);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;
        }

        public List<string> ListOutOfStockProducts()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "select products.ProductName from inventory join products on Products.ProductID=Inventory.ProductID where Inventory.QuantityInStock=0";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;
        }

        public bool RemoveFromInventory(int productId,int quantity)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "update inventory set quantityinstock = quantityinstock-@quantity where ProductID=@id";
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public bool UpdateStockQuantity(int id,int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "update inventory set quantityinstock = @newQuantity where ProductID=@id";
                cmd.Parameters.AddWithValue("@newquantity", newQuantity);
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
