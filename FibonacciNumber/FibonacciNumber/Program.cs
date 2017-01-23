using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumber
{
    class Program
    {

        // Fast doubling algorithm
        private static BigInteger Fibonacci(int n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;
            for (int i = 31; i >= 0; i--)
            {
                BigInteger d = a * (b * 2 - a);
                BigInteger e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }

        static long NthFibonacciSeries(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return NthFibonacciSeries(n-1) + NthFibonacciSeries(n-2);
        }
        static BigInteger NegativeNthFibonacciSeries(BigInteger n, long number)
        {
            BigInteger sign;
            BigInteger.TryParse(Math.Pow(-1, Math.Abs(number) + 1).ToString(CultureInfo.InvariantCulture), out sign);
            return  sign * n;
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
            Console.Write("Enter the nth number of the Fibonacci Series: ");
            //int length = Convert.ToInt32(Console.ReadLine());
            //for (int i = 0; i < length; i++)
            //{
            //    Console.Write("{0} ", FibonacciSeries(i));
            //}
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("{0} ", number < 0 ? NegativeNthFibonacciSeries(Fibonacci(Math.Abs(number)), number) : Fibonacci(number));
            Console.ReadKey();
        }
    }
}
