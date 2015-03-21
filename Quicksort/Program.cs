using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    //http://en.wikipedia.org/wiki/Quicksort
    //a very commonly used algorithm for sorting. When implemented well, 
    //it can be about two or three times faster than its main competitors, 
    //merge sort and heapsort.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quick Sort");
            Console.WriteLine();

            int[] A = { 4, 6, 8, 0, 5, 2, 1, 9, 3, 7 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(A);
            Quicksort(A, 0, A.Length - 1);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(A);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] B = { 4, 6, 8, 0, 5, 2, 1, 9, 16, 20, 7, 11, 14, 3, 12 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(B);
            Quicksort(B, 0, B.Length - 1);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(B);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] C = { 3, 5, 2, 1, 4 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(C);
            Quicksort(C, 0, C.Length - 1);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(C);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] D = { 4, 6, 1, 8, 4, 7, 7, 0, 5, 4, 2, 1, 9, 3, 7, 2 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(D);
            Quicksort(D, 0, D.Length - 1);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(D);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] E = { 4, 6, 1, 8, 4, 0, 5, 2, 1, 9, 3, 7 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(E);
            Quicksort(E, 0, E.Length - 1);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(E);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            Console.ReadLine();
        }

        static void PrintArray(int[] A)
        {
            Console.Write("[ ");
            foreach (int item in A)
            {
                Console.Write(", {0}", item);
            }
            Console.Write(" ]");
            Console.WriteLine();
        }

        static void Quicksort(int[] A, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(A, lo, hi);
                Quicksort(A, lo, p - 1);
                Quicksort(A, p + 1, hi);
            }
        }

        // lo is the index of the leftmost element of the subarray
        // hi is the index of the rightmost element of the subarray (inclusive)
        static int Partition(int[] A, int lo, int hi)
        {
            int pivotIndex = ChoosePivot(A, lo, hi);
            int pivotValue = A[pivotIndex];
            
            // put the chosen pivot at A[hi]
            Swap(pivotIndex, hi, A);
            int storeIndex = lo;

            // Compare remaining array elements against pivotValue = A[hi]
            //for i from lo to hi−1, inclusive
            for (int i = lo; i < hi; i++)
            {
                if (A[i] < pivotValue)
                {                                
                    Swap(i, storeIndex, A);
                    storeIndex = storeIndex + 1;
                }                
            }
            Swap(storeIndex, hi, A); // Move pivot to its final place
            return storeIndex;
        }

        static void Swap<T>(int a, int b, T[] arr)
        {
            T tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        static int ChoosePivot(int[] A, int lo, int hi)
        {
            char[] B = { 'c', 'b', 'a' };
            Swap(1, 2, B);

            //compute middle of array
            int mi = lo + ((hi - lo) / 2);

            //include leftmost, middle and rightmost 
            //elements in new array
            int[][] O = 
            {
                new int[] {A[lo], lo},
                new int[] {A[mi], mi},
                new int[] {A[hi], hi}
            };
                         

            //sort new array
            //smaller of two ends
            if (O[0][0] > O[2][0])
            {
                //swap
                Swap(0, 2, O);
            }
            //smaller of first and middle
            if (O[0][0] > O[1][0])
            {
                //swap
                Swap(0, 1, O);
            }
            //only if not swaped, check middle with last element
            else if (O[1][0] > O[2][0])
            {
                //swap
                Swap(1, 2, O);
            }

            //return element at the middle
            return O[1][1];
        }

    }
}
