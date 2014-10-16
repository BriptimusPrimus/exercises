using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with type conversions *****");
            short numb1 = 30000, numb2 = 30000;

            // Explicitly cast the int into a short (and allow loss of data).
            short answer = (short)Add(numb1, numb2);

            Console.WriteLine("{0} + {1} = {2}",
              numb1, numb2, answer);
            NarrowingAttempt();

            Console.WriteLine();
            ProcessBytes();

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;

            // Explicitly cast the int into a byte (no loss of data).
            myByte = (byte)myInt;
            Console.WriteLine("Value of myByte: {0}", myByte);
        }

        static void ProcessBytes()
        {
            //byte b1 = 100;
            //byte b2 = 250;
            //byte sum = (byte)Add(b1, b2);

            int myInt = 350;
            byte myByte = (byte)myInt;

            // sum should hold the value 350. However, we find the value 94!
            Console.WriteLine("sum = {0}", myByte);
        }

    }
}
