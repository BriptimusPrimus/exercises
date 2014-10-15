using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintThreeStrings();
            Console.WriteLine();

            ChangeDynamicDataType();
            Console.WriteLine();

            InvokeMembersOnDynamicData();
            Console.WriteLine();

            dynamic a = new object();
            
            // Error! Methods on dynamic data can't use lambdas!
            //a.Method(arg => Console.WriteLine(arg));

            // Error! Dynamic data can't find the Select() extension method!
            //var data = from d in a select d;

            Console.ReadLine();
        }

        static void ImplicitlyTypedVariable()
        {
            // a is of type List<int>.
            var a = new List<int>();
            a.Add(90);

            // This would be a compile-time error!
            // a = "Hello";
        }

        static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }

        static void ChangeDynamicDataType()
        {
            // Declare a single dynamic data point
            // named "t".
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }

        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Hello";
            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
