using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException() { }
        public InsufficientStockException(string message) : base(message) { }
    }
}
