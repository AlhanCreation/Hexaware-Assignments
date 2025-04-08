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
    internal class ProductRepository : IProductRepository
    {
        public string connectionString;
       
        internal SqlCommand cmd ;
        public ProductRepository()
        {
            connectionString = DBConnectionUtility.GetConnectedString();
            cmd = new SqlCommand();
        }

        public List<Product> GetAllProducts(int id)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select * from products where ProductID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductID = (int)reader["ProductID"];
                        product.ProductName = (string)reader["ProductName"];
                        product.Description = (string)reader["Description"];
                        product.Price = (decimal)reader["Price"];
                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int productId)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                connection.Open();
                cmd.CommandText = "select * from products where productid=@id";
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                Product product = new Product();
                while (reader.Read())
                {
                    
                    product.ProductID = (int)reader["ProductID"];
                    product.ProductName = (string)reader["ProductName"];
                    product.Description = (string)reader["ProductDescription"];
                    product.Price = (decimal)reader["Price"];
                }

                return product;

            }
         
        }

        public bool IsProductInStock(int id)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                cmd.CommandText = "select productid from inventory where productid=@id and QuantityInStock>0";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = conn;
                
                try
                {
                    result = (int)cmd.ExecuteScalar();
                }
                catch
                {
                    throw new InvalidDataException("Invalid ID given");
                }
            }
            return result > 0;
        }

        public bool UpdateProductInfo(int id)
        {
            bool result = false;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "update Products set price = price+(price*0.1) where ProductID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    int rowsEffected = cmd.ExecuteNonQuery();
                    result = rowsEffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
