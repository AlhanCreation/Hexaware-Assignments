using System;
namespace OperatorOverloding
{
    class Distance
    {
        public int dist;

        // Overloading the unary ++ operator
        public static Distance operator ++(Distance d)
        {
            d.dist++; 
            return d;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Distance d1 = new Distance();
            d1.dist = 10;

            Console.WriteLine("Original Distance: {0}", d1.dist);

            d1++; // Calls the overloaded ++ operator

            Console.WriteLine("Incremented Distance: {0}", d1.dist);
            Console.Read();
        }
    }
}






