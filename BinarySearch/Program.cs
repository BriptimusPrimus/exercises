using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{

    //http://en.wikipedia.org/wiki/Binary_search_algorithm
    //Binary search algorithm
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recursive Binary Search");
            Console.WriteLine();

            int[] A = { 4, 6, 8, 0, 5, 2, 1, 9, 3, 7 };
            Array.Sort(A);

            Console.WriteLine("Array: {0}; recursive search for index of 2: {1}", A,
                RecursiveBinarySearch(A, 2, 0, A.Length - 1));
            Console.WriteLine("Array: {0}; iterative search for index of 2: {1}", A,
                IterativeBinarySearch(A, 2, 0, A.Length - 1));


            int[] B = { 4, 6, 8, 0, 5, 2, 1, 9, 16, 20, 7, 11, 14, 3, 12 };
            Array.Sort(B);

            Console.WriteLine("Array: {0}; recursive search for index of 14: {1}", B,
                RecursiveBinarySearch(B, 14, 0, B.Length - 1));
            Console.WriteLine("Array: {0}; iterative search for index of 14: {1}", B,
                IterativeBinarySearch(B, 14, 0, B.Length - 1));


            int[] C = { 3, 5, 2, 1, 4 };
            Array.Sort(C);

            Console.WriteLine("Array: {0}; recursive search for index of 1: {1}", C,
                RecursiveBinarySearch(C, 1, 0, C.Length - 1));
            Console.WriteLine("Array: {0}; iterative search for index of 1: {1}", C,
                IterativeBinarySearch(C, 1, 0, C.Length - 1));

            Console.WriteLine("Array: {0}; recursive search for index of 7: {1}", C,
                RecursiveBinarySearch(C, 7, 0, C.Length - 1));
            Console.WriteLine("Array: {0}; iterative search for index of 7: {1}", C,
                IterativeBinarySearch(C, 7, 0, C.Length - 1));

            Console.ReadLine();
        }

        static int RecursiveBinarySearch(int[] A, int key, int imin, int imax)
        {
            if (imax >= A.Length || imin >= A.Length || imin < 0 || imax < 0)
            //index out of bounds
                return -1;

            // test if array is empty
            if (imax < imin)
                // set is empty, so return value showing not found
                return -1;
            else
            {
                // calculate midpoint to cut set in half
                int imid = imin + ((imax - imin) / 2);
 
                // three-way comparison
                if (A[imid] > key)
                    // key is in lower subset
                    return RecursiveBinarySearch(A, key, imin, imid - 1);
                else if (A[imid] < key)
                    // key is in upper subset
                    return RecursiveBinarySearch(A, key, imid + 1, imax);
                else
                    // key has been found
                    return A[imid];
            }
        }

        static int IterativeBinarySearch(int[] A, int key, int imin, int imax)
        {
            if (imax >= A.Length || imin >= A.Length || imin < 0 || imax < 0)
                //index out of bounds
                return -1;

            // continue searching while [imin,imax] is not empty
            while (imax >= imin)
            {
                // calculate the midpoint for roughly equal partition
                int imid = imin + ((imax - imin) / 2);

                if (A[imid] == key)
                    // key found at index imid
                    return A[imid];
                // determine which subarray to search
                else if (A[imid] < key)
                    // change min index to search upper subarray
                    imin = imid + 1;
                else
                    // change max index to search lower subarray
                    imax = imid - 1;
            }
            // key was not found
            return -1;            
        }

    }
}
