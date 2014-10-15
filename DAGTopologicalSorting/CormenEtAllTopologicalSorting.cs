using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAGTopologicalSorting
{
    //http://en.wikipedia.org/wiki/Topological_sorting
    //Implements Cormen et all/Tarjan algotithm for Topological Sorting of a DAG Graph
    //based on depth-first search
    public class CormenEtAllTopologicalSorting
    {
        static Stack<DirectedGraphNode> L = new Stack<DirectedGraphNode>();

        public static Stack<DirectedGraphNode> TopSort(DirectedGraphNode[] nodes)
        {
            L.Clear();
            foreach (var n in nodes)
            {
                if (n.Weight < 2)
                {
                    if (!Visit(n))
                    { 
                        //Not a DAG
                        return null;
                    }
                }
            }
            return L;
        }

        //note: 
        //weight = 0 = unvisited
        //weight = 1 = temporarily visited
        //weight = 2 = permanently visited             
        private static bool Visit(DirectedGraphNode n)
        {
            if (n.Weight == 1) //stop all (not a DAG)
                return false;
            
            if (n.Weight == 2)
                return true;
            
            n.Weight = 1; //mark node temporarily
            foreach (var m in n.Neighbors)
            {
                if (!Visit(m))
                {
                    return false; //not a DAG
                }
            }
            //mark node permanently and push it to the stack
            n.Weight = 2;
            L.Push(n);

            return true;
        }
    }
}
