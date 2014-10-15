using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsTherePathAlgorithm
{
    class AnyPathAlgorithm
    {
        public static List<string> FindFirstPath(DirectedGraphNode node, string end, List<string> path)
        {
            path.Add(node.Symbol);
            if (node.Symbol == end)
            {
                //we are done
                return path;
            }
            foreach (var neig in node.Neighbors)
            {
                //avoid looping
                if (!path.Contains(neig.Symbol))
                {
                    //recursion
                    var aux = FindFirstPath(neig, end, path.ToList());
                    //found anything? return it, else try with next neighbor
                    if (aux != null && aux.Contains(end))
                    {
                        return aux;
                    }
                }
            }
            //if we got here, we haven't find any path
            return null;
        }
    }
}
