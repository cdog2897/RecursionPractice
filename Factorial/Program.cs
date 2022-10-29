using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = 6;
            Console.WriteLine(factorial(startingNumber));
            Console.ReadLine();
        }

        static int factorial(int x)
        {
            Console.WriteLine("X is {0}", x);
            if (x == 1)
            {
                return 1;
            }
            else
            {
                return x * factorial(x - 1);
            }
        }
    }
}
