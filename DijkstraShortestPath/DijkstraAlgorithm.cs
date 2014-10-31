using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    // Finds shortest path to every node from a source in the graph
    // In this version all edge cost are equals one, therefore 
    // the distance between neighbors is the same in all cases
    class DijkstraAlgorithm
    {
        private DirectedGraphNode[] Graph;
        private int Source;

        List<DirectedGraphNode> Q = new List<DirectedGraphNode>();

        Dictionary<int, int> previous = new Dictionary<int, int>();

        public DijkstraAlgorithm(DirectedGraphNode[] graph, DirectedGraphNode source)
        {
            this.Graph = graph;
            this.Source = source.Symbol;

            //map all nodes from source
            Dijkstra(this.Graph, this.Source);
        }

        private void Dijkstra(DirectedGraphNode[] Graph, int source)
        {
            foreach (var v in Graph)                // Initializations
            {
                if (v.Symbol == source)
                    v.Weight = 0;
                else
                    v.Weight = int.MaxValue;        // Unknown distance function from source to v
                previous.Add(v.Symbol, -1);         // Previous node in optimal path from source                   
                Q.Add(v);                           // All nodes initially in Q (unvisited nodes)
            }

            while (Q.Count > 0)                     // The main loop
            {
                var u = Q.OrderBy(x => x.Weight)    // Source node in first case
                    .FirstOrDefault();
                Q.Remove(u);

                foreach (var v in u.Neighbors)      
                {
                    if (Q.Contains(v))              // where v has not yet been removed from Q.
                    {
                        int alt = u.Weight + 1;
                        if (alt < v.Weight)          // A shorter path to v has been found
                        {
                            v.Weight = alt;
                            previous[v.Symbol] = u.Symbol;
                        }
                    }
                }
            }
        }

        public int[] BackTrack(int target)
        {
            List<int> result = new List<int>();
            int u = target;
            while(previous[u] >= 0)                 // -1 is undefined
            {
                result.Add(u);
                u = previous[u];
            }
            result.Add(u);
            result.Reverse();
            return result.ToArray();
        }

    }
}
