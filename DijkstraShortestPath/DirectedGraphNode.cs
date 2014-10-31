using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    public class DirectedGraphNode
    {
        public List<DirectedGraphNode> Neighbors = new List<DirectedGraphNode>();

        public int Weight { get; set; }
        public int Symbol { get; set; }
        public char CharSymbol
        {
            get { return (char)Symbol; }
        }

        public DirectedGraphNode()
        {
            this.Weight = 0;
            this.Symbol = 0;
        }

        public DirectedGraphNode(int Symbol, int Weight = 0)
        {
            this.Symbol = Symbol;
            this.Weight = Weight;
        }
    }
}
