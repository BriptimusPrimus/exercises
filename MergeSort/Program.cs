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

            IntegerNode[] unordered = { 
                new IntegerNode(3),
                new IntegerNode(8),
                new IntegerNode(6),
                new IntegerNode(1),
                new IntegerNode(7),

                new IntegerNode(0),

                new IntegerNode(9),
                new IntegerNode(2),
                new IntegerNode(5),
                new IntegerNode(7),
                new IntegerNode(4),
            };

            LinkedList<IntegerNode> list = new LinkedList<IntegerNode>(unordered);

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
