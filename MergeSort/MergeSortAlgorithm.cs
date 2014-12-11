using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{

    //// http://en.wikipedia.org/wiki/Merge_sort

    class MergeSortAlgorithm
    {

        public static LinkedList<IntegerNode> MergeSort(LinkedList<IntegerNode> list)
        {
            // Base case. A list of zero or one elements is sorted, by definition.
            if (list.Count <= 1)
            {
                return list;            
            }

            // Recursive case. First, *divide* the list into equal-sized sublists.
            LinkedList<IntegerNode> left = new LinkedList<IntegerNode>();
            LinkedList<IntegerNode> right = new LinkedList<IntegerNode>();
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

        public static LinkedList<IntegerNode> merge(LinkedList<IntegerNode> left, LinkedList<IntegerNode> right) 
        {
            LinkedList<IntegerNode> result = new LinkedList<IntegerNode>();

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


    }
}
