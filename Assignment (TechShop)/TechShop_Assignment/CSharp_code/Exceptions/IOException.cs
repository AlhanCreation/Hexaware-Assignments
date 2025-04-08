using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    internal class IOException : Exception
    {
        public IOException() { }
        public IOException(string message) : base(message) { }
    }
}
