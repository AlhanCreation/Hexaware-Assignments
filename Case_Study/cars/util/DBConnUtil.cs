using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cars.util
{
    internal class DBConnUtil
    {
        public static SqlConnection GetSqlConnection()
        {
            //string connectionString = DBPropertyUtil.GetDBProperty("connectionString");
            
            SqlConnection conn = new SqlConnection("Data Source=HP\\SQLEXPRESS;Initial Catalog=carss;Integrated Security=True");
            try
            {
                conn.Open();
               
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e.Message);
                throw;
            }
            return conn;
        }
    }
}
