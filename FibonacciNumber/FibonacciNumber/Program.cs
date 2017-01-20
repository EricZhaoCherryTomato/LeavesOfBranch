using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumber
{
    class Program
    {
        static int NthFibonacciSeries(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return NthFibonacciSeries(n-1) + NthFibonacciSeries(n-2);
        }
        static void Main(string[] args)
        {

            Console.Write("Enter the nth number of the Fibonacci Series: ");
            int number = Convert.ToInt32(Console.ReadLine());
            number = number - 1;
            //We have to decrement the length because the series starts with 0  
            Console.Write(NthFibonacciSeries(number));
            Console.ReadKey();
        }
    }
}
