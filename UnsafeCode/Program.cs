using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Calling method with unsafe code *****");

            // Values for swap.
            int i = 10, j = 20;

            // Swap values "safely."
            Console.WriteLine("\n***** Safe swap *****");
            Console.WriteLine("Values before safe swap: i = {0}, j = {1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            // Swap values "unsafely."
            Console.WriteLine("\n***** Unsafe swap *****");
            Console.WriteLine("Values before unsafe swap: i = {0}, j = {1}", i, j);

            unsafe { UnsafeSwap(&i, &j); }

            Console.WriteLine("Values after unsafe swap: i = {0}, j = {1}", i, j);
            Console.ReadLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            // Square the value just for a test.
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void PrintValueAndAddress()
        {
            int myInt;

            // Define an int pointer, and
            // assign it the address of myInt.
            int* ptrToMyInt = &myInt;

            // Assign value of myInt using pointer indirection.
            *ptrToMyInt = 123;

            // Print some stats.
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        unsafe public static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        unsafe static void UsePointerToPoint()
        {
            // Access members via pointer.
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            // Access members via pointer indirection.
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        unsafe static void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
                p[k] = (char)k;
        }

        unsafe static void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
        }
    }

    // This entire structure is "unsafe" and can
    // be used only in an unsafe context.
    unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;
    }

    // This struct is safe, but the Node2* members
    // are not. Technically, you may access "Value" from
    // outside an unsafe context, but not "Left" and "Right".
    public struct Node2
    {
        public int Value;

        // These can be accessed only in an unsafe context!
        public unsafe Node2* Left;
        public unsafe Node2* Right;
    }

    struct Point
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }

}
