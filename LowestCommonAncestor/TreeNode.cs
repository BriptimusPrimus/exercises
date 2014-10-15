using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    public class TreeNode
    {
        public List<TreeNode> Children = new List<TreeNode>();

        public TreeNode Parent { get; set; }
        public int Symbol { get; set; }
        public char CharSymbol 
        {
            get { return (char)Symbol; }
        }

        public TreeNode()
        {
            this.Parent = null;
            this.Symbol = 0;
        }

        public TreeNode(int Symbol, TreeNode Parent = null)
        {
            this.Parent = Parent;
            this.Symbol = Symbol;
        }

        //public static bool operator ==(TreeNode b1, TreeNode b2)
        //{
        //    if (b1 == null && b2 == null)
        //        return true;
        //    if ((b1 == null && b2 != null) || (b1 != null && b2 == null))
        //        return false;
        //    return b1.Symbol == b2.Symbol;
        //}

        //public static bool operator !=(TreeNode b1, TreeNode b2)
        //{
        //    if (b1 == null && b2 == null)
        //        return false;
        //    if ((b1 == null && b2 != null) || (b1 != null && b2 == null))
        //        return true;
        //    return b1.Symbol != b2.Symbol;
        //}
    }
}
