namespace ConsoleApp1
{
    internal class Program
    {
        
        private static int count = 0;

      
        public static void CountFunction()
        {
            count++; //  counter
            Console.WriteLine($"Function called {count} times.");
        }

        static void Main(string[] args)
        {
            // Calling the function multiple times
            CountFunction();
            CountFunction();
            CountFunction();

          
            Console.ReadLine();
        }
    }
}
