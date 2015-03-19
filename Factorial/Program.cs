using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Recursive Factorial");
            Console.WriteLine();

            Console.WriteLine("5! = {0}", RecursiveFactorial(5));
            Console.WriteLine("4! = {0}", RecursiveFactorial(4));
            Console.WriteLine("6! = {0}", RecursiveFactorial(6));
            Console.WriteLine("1! = {0}", RecursiveFactorial(1));
            Console.WriteLine("0! = {0}", RecursiveFactorial(0));
            try
            {
                RecursiveFactorial(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("-1! = {0}", e.Message);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Iterative Factorial");
            Console.WriteLine();

            Console.WriteLine("5! = {0}", IterativeFactorial(5));
            Console.WriteLine("4! = {0}", IterativeFactorial(4));
            Console.WriteLine("6! = {0}", IterativeFactorial(6));
            Console.WriteLine("1! = {0}", IterativeFactorial(1));
            Console.WriteLine("0! = {0}", IterativeFactorial(0));
            try
            {
                IterativeFactorial(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("-1! = {0}", e.Message);
            }

            Console.ReadLine();
        }

        static int RecursiveFactorial(int n)
        {
            if (n < 0)            
                throw new Exception("Negative Number");

            if (n <= 1)
                return 1;

            return n * RecursiveFactorial(n - 1);
        }

        static int IterativeFactorial(int n)
        {
            if (n < 0)
                throw new Exception("Negative Number");

            int result = 1;
            while (n > 0)
            {
                result *= n--;
            }

            return result;
        }
    }
}
