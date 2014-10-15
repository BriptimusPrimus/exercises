using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class HuffmanNode
    {
        public HuffmanNode Left = null;
        public HuffmanNode Right = null;
        public int Weight;
        public string Symbol;

        public HuffmanNode()
        {
            this.Weight = 0;
            this.Symbol = String.Empty;
        }

        public HuffmanNode(string Symbol, int Weight)
        {
            this.Symbol = Symbol;
            this.Weight = Weight;
        }

    }
}
