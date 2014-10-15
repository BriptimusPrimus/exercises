using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsTherePathAlgorithm
{
    class DirectedGraphNode
    {
        public List<DirectedGraphNode> Neighbors = new List<DirectedGraphNode>();

        public int Weight { get; set; }
        public string Symbol { get; set; }

        public DirectedGraphNode()
        {
            this.Weight = 0;
            this.Symbol = String.Empty;
        }

        public DirectedGraphNode(string Symbol, int Weight = 0)
        {
            this.Symbol = Symbol;
            this.Weight = Weight;
        }
    }
}
