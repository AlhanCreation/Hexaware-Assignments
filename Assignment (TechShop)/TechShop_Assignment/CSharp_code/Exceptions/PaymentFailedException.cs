using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    internal class PaymentFailedException : Exception
    {
        public PaymentFailedException() { }
        public PaymentFailedException(string message) : base(message) { }
    }
}
