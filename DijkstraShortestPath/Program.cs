using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Dijkstra Shortest Path Algorithm*************");

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
                { 0, 1, 1, 1, 0, 0, 0, 0 }, //A
                { 1, 0, 1, 0, 0, 0, 0, 1 }, //B
                { 1, 1, 0, 0, 0, 0, 0, 0 }, //C
                { 1, 1, 1, 0, 0, 0, 1, 0 }, //D
                { 0, 1, 0, 1, 0, 1, 1, 1 }, //E
                { 0, 0, 0, 0, 1, 0, 1, 0 }, //F
                { 0, 0, 0, 1, 0, 1, 0, 0 }, //G
                { 0, 0, 0, 0, 1, 0, 0, 0 }, //H
            };
            EvalMatrix(mat2, "H");

            int[,] mat3 = new int[26, 26] 
            { 
                //A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z
                { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //A
                { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //B
                { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //C
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //D
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //E
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //F
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //G
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //H
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //I
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }, //J
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //K
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //L
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //M
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //N
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }, //O
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //P
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //Q
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //R
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }, //S
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 }, //T
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //U
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //V
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //W
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //X
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //Y
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }  //Z				
            };
            EvalMatrix(mat3, "P");

            Console.ReadLine();
        }

        static DirectedGraphNode[] GraphFactory(int[,] matrix)
        {
            byte asciiSymbol = 65;
            DirectedGraphNode[] arr = new DirectedGraphNode[matrix.GetLength(0)];
            for (int i = 0; i < arr.Length; i++)
            {
                DirectedGraphNode node = new DirectedGraphNode(asciiSymbol++);
                arr[i] = node;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        arr[i].Neighbors.Add(arr[j]);
                    }
                }
            }
            return arr;
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

            DirectedGraphNode[] arr = GraphFactory(matrix);
            //arr = arr.Reverse().ToArray();

            DirectedGraphNode start = arr[0];
            DijkstraAlgorithm alg = new DijkstraAlgorithm(arr, start);
            int[] path = alg.BackTrack((int)end[0]);
            Console.WriteLine("Shortest path from {0} to {1}: ", start.CharSymbol, end);
            foreach (int i in path)
            {
                Console.Write("{0}, ", (char)i);
            }

            Console.WriteLine();
        }
    }
}
