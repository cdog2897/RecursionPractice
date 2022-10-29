using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type an integer.");
            int startingNumber = int.Parse(Console.ReadLine());
            int x = countToOne(startingNumber);
            Console.ReadLine();

        }

        static public int countToOne(int n)
        {
            Console.WriteLine("N is {0}", n);
            if(n == 1)
            {
                return 1;
            }
            else
            {
                if(n % 2 == 0)
                {
                    Console.WriteLine("N is even, divide by 2");
                    return countToOne(n / 2);
                }
                else
                {
                    Console.WriteLine("N is odd, Add 1");
                    return countToOne(n + 1);
                }
            }

        }

    }
}
