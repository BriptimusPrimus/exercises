using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    // Interfaces cannot contain operators
    public interface IComparableNode : IComparable
    {
        //static bool operator <(IComparableNode n1, IComparableNode n2);

        //static bool operator >(IComparableNode n1, IComparableNode n2);

        //static bool operator <=(IComparableNode n1, IComparableNode n2);

        //static bool operator >=(IComparableNode n1, IComparableNode n2);
    }

    class IntegerNode : IComparableNode
    {
        public int Value { get; set; }

        public IntegerNode(int value)
        {
            this.Value = value;
        }

        // implement IComparable
        public int CompareTo(object obj)
        {
            IntegerNode other = obj as IntegerNode;
            if (this.Value > other.Value)
                return 1;
            if (this.Value < other.Value)
                return -1;
            else
                return 0;
        }

        //Overload the operators:
        public static bool operator <(IntegerNode n1, IntegerNode n2)
        {
            return (n1.CompareTo(n2) < 0);
        }

        public static bool operator >(IntegerNode n1, IntegerNode n2)
        {
            return (n1.CompareTo(n2) > 0);
        }

        public static bool operator <=(IntegerNode n1, IntegerNode n2)
        {
            return (n1.CompareTo(n2) <= 0);
        }

        public static bool operator >=(IntegerNode n1, IntegerNode n2)
        {
            return (n1.CompareTo(n2) >= 0); 
        }

        public override string ToString() 
        {
            return this.Value.ToString();
        }
    }

}
