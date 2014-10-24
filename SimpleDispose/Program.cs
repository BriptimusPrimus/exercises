using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Create a disposable object and call Dispose()
            // to free any internal resources.
            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable)
                rw.Dispose();
            Console.ReadLine();

            ChildClass child = new ChildClass();
            child.Run();
            ((MyResourceWrapper)child).Run();

            byte a = (byte)child.Run();
            Console.WriteLine("result = {0}", a);

            child.Dispose();
            Console.ReadLine();
        }

        // Implementing IDisposable.
        class MyResourceWrapper : IDisposable
        {
            public int Run()
            {
                Console.WriteLine("Run from Base");
                return 0;
            }


            // The object user should call this method
            // when they finish with the object.
            public void Dispose()
            {
                // Clean up unmanaged resources...

                // Dispose other contained disposable objects...

                // Just for a test.
                Console.WriteLine("***** In Dispose! *****");
            }
        }

        //Shadowing Testing
        class ChildClass : MyResourceWrapper
        {
            new public int Run()
            {
                Console.WriteLine("Shadowing Run");
                return 1;
            }        
        }

    }
}
