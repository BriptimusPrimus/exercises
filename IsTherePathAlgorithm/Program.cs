using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsTherePathAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Any Path to Node Algorithm*************");

            int[,] mat0 = new int[4, 4] 
            { 
                { 0, 1, 0, 1 }, 
                { 0, 1, 1, 1 }, 
                { 0, 1, 0, 0 }, 
                { 0, 0, 1, 0 }
            };
            EvalMatrix(mat0, "D");

            int[,] mat1 = new int[6, 6] 
            { 
                { 0, 0, 1, 1, 1, 0 }, 
                { 0, 0, 1, 1, 1, 1 }, 
                { 1, 1, 1, 1, 1, 0 }, 
                { 1, 1, 1, 1, 0, 0 },
                { 0, 1, 1, 0, 0, 0 }, 
                { 0, 0, 0, 0, 1, 0 } 
            };
            EvalMatrix(mat1, "F");

            int[,] mat2 = new int[8, 8] 
            { 
                //A  B  C  D  E  F  G  H
                { 0, 1, 1, 1, 0, 0, 0, 1 }, //A
                { 1, 0, 1, 0, 0, 0, 0, 0 }, //B
                { 1, 1, 0, 0, 0, 0, 0, 0 }, //C
                { 1, 1, 1, 0, 0, 0, 1, 0 }, //D
                { 0, 1, 0, 1, 0, 1, 1, 1 }, //E
                { 0, 0, 0, 0, 1, 0, 1, 0 }, //F
                { 0, 0, 0, 1, 0, 1, 0, 0 }, //G
                { 0, 0, 0, 0, 1, 0, 0, 0 }, //H
            };
            EvalMatrix(mat2, "H");

            Console.ReadLine();
        }

        static DirectedGraphNode GraphFactory(int[,] matrix)
        {
            byte asciiSymbol = 65;
            DirectedGraphNode[] arr = new DirectedGraphNode[matrix.GetLength(0)];
            for (int i = 0; i < arr.Length; i++)
            {
                DirectedGraphNode node = new DirectedGraphNode(((char)asciiSymbol++).ToString());
                arr[i] = node;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        arr[i].Neighbors.Add(arr[j]);
                    }
                }
            }
            return arr[0];
        }

        public static void EvalMatrix(int[,] matrix, string end)
        {
            Console.WriteLine("\r\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" {0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\r\n");

            DirectedGraphNode start = GraphFactory(matrix);
            List<string> path = AnyPathAlgorithm.FindFirstPath(start, end, new List<string>());
            if (path == null)
            {
                Console.WriteLine("No path from {0} to {1}", start.Symbol, end);
            }
            else
            {
                Console.WriteLine("First path from {0} to {1}: ", start.Symbol, end);
                foreach (string s in path)
                {
                    Console.Write("{0}, ", s);
                }
            }
            Console.WriteLine();
        }

    }
}
