using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heapsort
{
    //http://en.wikipedia.org/wiki/Heapsort
    class Program
    {
        //The complete binary tree maps the binary tree structure into 
        //the array indices; each array index represents a node; 
        //For a zero-based array, the root node is stored at index 0; 
        //if i is the index of the current node, then
        //iParent     = floor((i-1) / 2)
        //iLeftChild  = 2*i + 1
        //iRightChild = 2*i + 2
        static void Main(string[] args)
        {
            Console.WriteLine("Quick Sort");
            Console.WriteLine();

            int[] A = { 4, 6, 8, 0, 5, 2, 1, 9, 3, 7 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(A);
            Hapsort(A);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(A);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] B = { 4, 6, 8, 0, 5, 2, 1, 9, 16, 20, 7, 11, 14, 3, 12 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(B);
            Hapsort(B);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(B);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] C = { 3, 5, 2, 1, 4 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(C);
            Hapsort(C);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(C);
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int[] D = { 4, 6, 1, 8, 4, 7, 7, 0, 5, 4, 2, 1, 9, 3, 7, 2 };
            Console.WriteLine("Unsorted Array: ");
            PrintArray(D);
            Hapsort(D);
            Console.WriteLine("Quick Sort Array: ");
            PrintArray(D);
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

        static void Hapsort(int[] A)
        {
            int count = A.Length;
            // Build the heap in array a so that largest value is at the root
            Heapify(A);

            // The following loop maintains the invariants that a[0:end] is a heap and every element
            // beyond end is greater than everything before it (so a[end:count] is in sorted order))
            int end = count - 1;
            while (end > 0)
            {
                // a[0] is the root and largest value. The swap moves it in front of the sorted elements.
                Swap(end, 0, A);
                // the heap size is reduced by one
                end--;
                // the swap ruined the heap property, so restore it
                SiftDown(A, 0, end);
            }
        }

        //Put elements of 'a' in heap order, in-place
        static void Heapify(int[] A)
        {
            int count = A.Length;
            //start is assigned the index in 'a' of the last parent node
            //the last element in a 0-based array is at index count-1; find the parent of that element
            int start = ((count - 2) / 2);

            while (start >= 0)
            {
                //sift down the node at index 'start' to the proper place such that all nodes below
                //the start index are in heap order
                SiftDown(A, start, count - 1);
                //go to the next parent node
                start--;
            }
            //after sifting down the root all nodes/elements are in heap order
        }

        //Repair the heap whose root element is at index 'start', assuming the heaps rooted at its children are valid
        static void SiftDown(int[] A, int start, int end)
        {
            int root = start;
            int child, swap;

            while ((root * 2 + 1) <= end) //While the root has at least one child
            {
                child = root * 2 + 1; //Left child
                swap = root; //Keeps track of child to swap with

                if (A[swap] < A[child])
                {
                    swap = child;
                }
                
                // If there is a right child and that child is greater
                if (child + 1 <= end && A[swap] < A[child + 1])
                {
                    swap = child + 1;
                }

                if (swap == root)
                {
                    // The root holds the largest element. Since we assume the heaps rooted at the
                    // children are valid, this means that we are done.
                    return;
                }
                else
                {
                    Swap(root, swap, A);
                    root = swap; //repeat to continue sifting down the child now
                }
            }
        }

        static void Swap<T>(int a, int b, T[] arr)
        {
            T tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }
    }
}
