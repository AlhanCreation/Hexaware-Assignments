using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    internal class AuthorizationException : Exception
    {
        public AuthorizationException() { }
        public AuthorizationException(string message) : base(message) { }
    }
}
