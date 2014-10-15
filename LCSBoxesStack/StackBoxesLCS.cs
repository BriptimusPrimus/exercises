using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSBoxesStack
{
    //You are asked to stack boxes to form a tower. 
    //For practical and safety reasons, each box must be 
    //smaller and lighter than the box below of it.
    public class StackBoxesLCS
    {
        public static Stack<Box> StackBoxes(List<Box> boxes)
        {
            //in order to work correctly, must add a first fake element
            //this element will be ignored in comparisons due to the fact 
            //that the algorithm starts at index 1
            boxes.Add(new Box(0, 0, 0));

            var byHeight = boxes.OrderBy(x => x.height).ToArray();
            var byWeight = boxes.OrderBy(x => x.weight).ToArray();

            int[,] table = LCSTable(byHeight, byWeight);

            int i = table.GetLength(0) - 1;
            int j = table.GetLength(1) - 1;
            var result = backtrack(new Stack<Box>(), table, byHeight, byWeight, i, j);
            
            return result;
        }

        private static int max(int a, int b)
        {
            return b > a ? a : b;
        }

        private static int[,] LCSTable(Box[] X, Box[] Y)
        { 
            int m = X.Length;
            int n = Y.Length;
            int[,] C = new int[m, n];
            for (int i = 0; i < m; i++)
                C[i, 0] = 0;
            for (int j = 0; j < n; j++)
                C[0, j] = 0;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (X[i] == Y[j])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        C[i, j] = max(C[i, j - 1], C[i - 1, j]);
                    }
                }
            }
            return C;            
        }

        private static Stack<Box> backtrack(Stack<Box> tower, int[,] C, Box[] X, Box[] Y, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return tower;
            }

            if  (X[i] == Y[j])
            {
                tower.Push(X[i]);
                return backtrack(tower, C, X, Y, i-1, j-1);
            }
            else
            {
                if (C[i,j-1] > C[i-1,j])
                {
                    return backtrack(tower, C, X, Y, i, j - 1);
                }
                else
                {
                    return backtrack(tower, C, X, Y, i - 1, j);
                }
            }
        }

        private static Stack<Box> backtrackBK(int[,] C, Box[] X, Box[] Y, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return new Stack<Box>();
            }

            if (X[i] == Y[j])
            {
                var tower = backtrackBK(C, X, Y, i - 1, j - 1);
                tower.Push(X[i]);
                return tower;
            }
            else
            {
                if (C[i, j - 1] > C[i - 1, j])
                {
                    return backtrackBK(C, X, Y, i, j - 1);
                }
                else
                {
                    return backtrackBK(C, X, Y, i - 1, j);
                }
            }
        }
    }
}
