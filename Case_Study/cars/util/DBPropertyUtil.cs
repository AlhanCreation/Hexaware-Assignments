using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cars.util
{
    internal class DBPropertyUtil
    { 
        public static string GetDBProperty(string connectionString)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db.properties");
           
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("db.properties file not found.");
            }
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (line.StartsWith( connectionString+ "="))
                {
                    return line.Substring(line.IndexOf('=') + 1).Trim();
                }
            }
            throw new KeyNotFoundException($"Key '{connectionString}' not found in db.properties.");
        }

    }
}
