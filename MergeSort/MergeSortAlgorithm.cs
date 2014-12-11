using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{

    //// http://en.wikipedia.org/wiki/Merge_sort

    static class MergeSortAlgorithm
    {

        public static LinkedList<int> MergeSort(LinkedList<int> list)
        {
            // Base case. A list of zero or one elements is sorted, by definition.
            if (list.Count <= 1)
            {
                return list;            
            }

            // Recursive case. First, *divide* the list into equal-sized sublists.
            LinkedList<int> left = new LinkedList<int>();
            LinkedList<int> right = new LinkedList<int>();
            int middle = list.Count / 2;

            // for each x in list before middle, add x to left 
            for (int i = 0; i < middle; i++)
            {
                left.AddLast(list.First());
                list.RemoveFirst();
            }

            //for each x in list after or equal middle, add x to right
            while (list.Count > 0)
            {
                right.AddLast(list.First());
                list.RemoveFirst();
            }

            // Recursively sort both sublists.
            left = MergeSort(left);
            right = MergeSort(right);

            // *Conquer*: merge the now-sorted sublists.
            return merge(left, right);            
        }

        public static LinkedList<int> merge(LinkedList<int> left, LinkedList<int> right) 
        {
            LinkedList<int> result = new LinkedList<int>();

            //// assign the element of the sublists to 'result' variable until there is no element to merge. 
            //while notempty(left) or notempty(right)
            while (left.Count > 0 || right.Count > 0)
            {
                // if notempty(left) and notempty(right)
                if (left.Count > 0 && right.Count > 0)
                {
                    //// compare the first elements of the two sublists.
                    if (left.First() <= right.First())
                    {
                        // append first(left) to result, left = rest(left)
                        result.AddLast(left.First()); 
                        left.RemoveFirst();             
                    }                    
                    else 
                    {
                        // append first(right) to result, right = rest(right)
                        result.AddLast(right.First());  
                        right.RemoveFirst();          
                    }                    
                }
                // else if notempty(left)
                else if (left.Count > 0)
                {
                    // append first(left) to result, left = rest(left)
                    result.AddLast(left.First());  
                    left.RemoveFirst();           
                }
                // else if notempty(right)
                else if (right.Count > 0)
                {
                    // append first(right) to result, right = rest(right)
                    result.AddLast(right.First()); 
                    right.RemoveFirst();         
                }
            }

            return result;
        }

        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }

    }
}
