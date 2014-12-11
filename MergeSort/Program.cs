using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************Merge Sort Algorithm******************");

            int[] unordered = { 3, 8, 6, 1, 7, 0, 9, 2, 5, 7, 4 };

            LinkedList<int> list = new LinkedList<int>(unordered);

            Console.WriteLine("Unordered List: ");
            PrintList(list);

            list = MergeSortAlgorithm.MergeSort(list);
            Console.WriteLine();

            Console.WriteLine("Ordered List:");
            PrintList(list);

            Console.ReadLine();
        }

        static void PrintList<T>(LinkedList<T> list) 
        {
            foreach (var x in list) 
            {
                Console.WriteLine(" -> {0}", x);
            }
        }
    }
}
