
namespace TechShop.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
    }
}
