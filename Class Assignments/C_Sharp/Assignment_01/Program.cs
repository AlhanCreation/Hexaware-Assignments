using System;

namespace ConsoleApp1
{

    internal class Program
    {

        static void Main(string[] args)
        {
           checkEqualIntergers();
           // checkPositiveIntegers();
           // arithmethicOperations();
            // {
            //     Console.Write("Enter the number: ");
            //     int num = Convert.ToInt32(Console.ReadLine());

            //     Console.WriteLine($"Multiplication table of {num}:");

            //     for (int i = 0; i <= 10; i++)
            //     {
            //         Console.WriteLine($"{num} * {i} = {num * i}");
            //     }
            // }

        }
        public static void checkEqualIntergers()
        {
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            string result = num1 != num2 ? "Both numbers are not equal." : "Both numbers are equal.";
            Console.Write(result);
        }
        public static void checkPositiveIntegers()
        {
            Console.Write("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"{num} is a negative number.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }
        }
        public static void arithmethicOperations()
        {
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input operation (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case '+':
                    Console.Write($"{num1} + {num2} " + (num1 + num2));
                    break;
                case '-':
                    Console.Write($"{num1} - {num2} " + (num1 - num2));
                    break;
                case '*':
                    Console.Write($"{num1} * {num2} " + (num1 * num2));
                    break;
                case '/':
                    Console.Write($"{num1} / {num2} " + (num1 / num2));
                    break;
                default:
                    Console.WriteLine("Invalid operation! Please enter +, -, *, or /.");
                    break;
            }
        }
        //public static void jaggedArray(){
        //    int[][] jaggedArray = new int[3][];

        //      for (int i = 0; i < jaggedArray.Length; i++)
        //        {
        //            jaggedArray[i] = new int[i + 1]; // Assign different-sized rows
        //            for (int j = 0; j < jaggedArray[i].Length; j++)
        //            {
        //                jaggedArray[i][j] = (i + 1) * 10 + j; // Assign values dynamically
        //            }
        //        }
        //}

            
    }
}
