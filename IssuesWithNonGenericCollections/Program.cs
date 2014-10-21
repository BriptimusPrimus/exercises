using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleBoxUnboxOperation();

            Console.ReadLine();
        }

        static void SimpleBoxUnboxOperation()
        {
            // Make a ValueType (int) variable.
            int myInt = 25;

            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox the reference back into a corresponding int.
            //int unboxedInt = (int)boxedInt;

            // Unbox in the wrong data type to trigger
            // runtime exception.
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
