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

        //static int NegativeNthFibonacciSeries(int n)
        //{
        //    return Math.Pow(-1, n + 1) * NthFibonacciSeries(n);
        //}

        static long FibonacciSeries(long n)
        {
            long firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber - secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.Write(-1-1);
            Console.Write("Enter the nth number of the Fibonacci Series: ");
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", FibonacciSeries(i));
            }
            Console.ReadKey();
        }
    }
}
