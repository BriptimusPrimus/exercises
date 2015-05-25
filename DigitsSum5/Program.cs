using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsSum5
{

    //Given the number range from 1 to 200, return all the numbers whose digit sum equals 5.
    //Example: 
    //99 = 9 + 9 = 18
    //32 = 3 + 2 = 5
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Return all the numbers whose digit sum equals 5");
            Console.WriteLine();

            Console.WriteLine("1 - 28: "); PrintListValues<int>(NumbersWhoseDigitsSumFive(1, 28));
            Console.WriteLine("1 - 200: "); PrintListValues<int>(NumbersWhoseDigitsSumFive(1, 200));
            Console.WriteLine("0 - 1: "); PrintListValues<int>(NumbersWhoseDigitsSumFive(0, 1));
            Console.WriteLine("6 - 5: "); PrintListValues<int>(NumbersWhoseDigitsSumFive(6, 5));

            Console.ReadLine();
        }

        static List<int> NumbersWhoseDigitsSumFive(int i, int j)
        {
            List<int> result = new List<int>();
            for (int n = i; n < j; n++)
            { 
                int number = n;
                //Console.WriteLine("num = {0}", number);

                int acumulator = 0; 
                while(number > 0 && acumulator < 5)
                {                    
                    acumulator += number % 10;
                    number /= 10;


                    //Console.WriteLine("acm = {0}", acumulator);
                    //Console.WriteLine("num = {0}", number);
                    //Console.WriteLine("------------------");
                    //Console.WriteLine();
                }

                if (number == 0 && acumulator == 5)
                {
                    result.Add(n);
                }
            }
            return result;
        }

        static void PrintListValues<T>(List<T> list)
        { 
            Console.Write("[ ");
            foreach(T item in list)
            {
                Console.Write(", {0}", item);
            }
            Console.Write(" ]");
            Console.WriteLine();
        }

    }
}
