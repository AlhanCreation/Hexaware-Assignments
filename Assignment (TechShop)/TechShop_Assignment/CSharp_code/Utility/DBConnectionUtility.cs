using System;
using System.Data.SqlClient;
using DotNetEnv;
using TechShop.Exceptions;

namespace TechShop.Utility
{
    internal class DBConnectionUtility
    {
        private static string _connectionString;

        static DBConnectionUtility()
        {
            LoadEnvironmentVariables();
        }

        private static void LoadEnvironmentVariables()
        {
            // Load the .env file
            Env.Load("Utility/.env");
            _connectionString = Env.GetString("DB_CONNECTION_STRING");
        }

        public static string GetConnectedString()
        {   
        
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                
                connection.Open();
                return _connectionString;
            }
            catch (SqlException se)
            {   
                throw new DatabaseConnectionException("SQL Error connecting to the database", se);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("General error connecting to the database", ex);
            }

        }

       
       
    }
}
