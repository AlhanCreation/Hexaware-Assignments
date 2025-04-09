using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;


namespace OrderManagementSystem.util
{
    public class DBUtil
    {
        public static SqlConnection GetDBConn()
        {
            SqlConnection conn = new SqlConnection("Data Source=HP\\SQLEXPRESS;Initial Catalog=oms;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
