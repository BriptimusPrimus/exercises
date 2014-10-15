using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    public class LCASolution
    {
        //resolves the parent of every node
        public static void PreProcessTree(TreeNode node)
        { 
            foreach(TreeNode child in node.Children)
            {
                child.Parent = node;
                PreProcessTree(child);
            }
        }

        public static TreeNode linearLCA(TreeNode node1, TreeNode node2) 
        {
            Stack<TreeNode> parentNode1 = new Stack<TreeNode>();
            while (node1 != null) 
            {
                parentNode1.Push(node1);
                node1 = node1.Parent;
            }
            Stack<TreeNode> parentNode2 = new Stack<TreeNode>();
            while (node2 != null) 
            {
                 parentNode2.Push(node2);
                 node2 = node2.Parent;
            }

            TreeNode oldNode = null;
            while ((node1 == node2 || node1.Symbol == node2.Symbol)
                && parentNode1.Count > 0 
                && parentNode2.Count > 0) 
            {
                oldNode = node1;
                node1 = parentNode1.Pop();
                node2 = parentNode2.Pop();
            }
            if (node1 == node2) 
                return node1;   // One node is descended from the other
            else return 
                oldNode;        // Neither is descended from the other
        }
    }
}
